using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SGU_Reporting_Tool
{
    static class Program
    {
        public const int TableLayoutRowHeight = 50;
        public const string WorkingServer = "jenzabardb";
        public const string WorkingDB = "TmsEPrd";
        public const string ReportTable = "Verf_Tool_Reports";
        public const string StudTermSumDivTable = "stud_term_sum_div";
        public const string InfoMakerExecKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\im115.exe";
        public const bool FakingSqlConn = false; // Debugging

        private static bool _hasSQLConnMade = false;
        private static SqlConnection _sqlConn = null;
        private static SecureString _sqlConnUsername = null;
        private static SecureString _sqlConnPassword = null;
        private static string _infoMakerExecLoc = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Figure out info maker program executable location.
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            rk = rk.OpenSubKey(InfoMakerExecKey);
            object rkValue = null;

            if (rk != null && (rkValue = rk.GetValue("")) != null)
            {
                _infoMakerExecLoc = rkValue.ToString();
            }
            else
            {
                MessageBox.Show("Cannot find InfoMaker executable location. Running of InfoMaker reports will not be available.", "Missing Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new MainWindow());
        }

        public static string InfoMakerExecLocation
        {
            get { return _infoMakerExecLoc; }
        }

        public static DialogResult TryMakeSQLConnection()
        {
            if (_hasSQLConnMade)
                return DialogResult.OK;

            CredentialsWindow window = new CredentialsWindow();
            if (DialogResult.OK != window.ShowDialog())
                return DialogResult.Cancel;
            
            if (!FakingSqlConn)
            {
                // U/n p/w in a read-only secured string at this point.
                _sqlConnUsername = window.Username;
                _sqlConnPassword = window.Password;

                IntPtr connUsername = Marshal.SecureStringToBSTR(_sqlConnUsername);
                IntPtr connPassword = Marshal.SecureStringToBSTR(_sqlConnPassword);
                string sqlConnStr = "user id=" + Marshal.PtrToStringBSTR(connUsername) + ";" +
                                    "password=" + Marshal.PtrToStringBSTR(connPassword) + ";" +
                                    "server=" + WorkingServer + ";" +
                                    //"Trusted_Connection=yes;" +
                                    "database=" + WorkingDB + "; " +
                                    "connection timeout=30";
                Marshal.ZeroFreeBSTR(connUsername);
                Marshal.ZeroFreeBSTR(connPassword);

                _sqlConn = new SqlConnection(sqlConnStr);
                try
                {
                    _sqlConn.Open();
                }
                catch
                {
                    return DialogResult.Abort;
                }
            }

            _hasSQLConnMade = true;
            return DialogResult.OK;
        }

        public static void RunVerify(string domainCode, string yearTermCode, TableLayoutPanel tablePanel, ProgressBar progressBar)
        {
            // Prep report factory for correct student totals.
            ReportFactory factory = new ReportFactory();
            factory.GetTotalStudentCount(yearTermCode, ref _sqlConn);

            // Delete current contents.
            tablePanel.Invoke(new MethodInvoker(delegate
            {
                tablePanel.Controls.Clear();
                tablePanel.RowStyles.Clear();
            }));

            // Grab reports listing.
            string sqlCmdStr = "SELECT * FROM [" + WorkingDB + "].[barobba].[" +
                ReportTable + "] WHERE [Domain] = '" + domainCode + "';";
            SqlCommand sqlCmd = new SqlCommand(sqlCmdStr);
            sqlCmd.Connection = _sqlConn;

            List<Dictionary<string, string>> reportItems = new List<Dictionary<string,string>>();

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                Dictionary<string, string> report = new Dictionary<string, string>(6);

                if (report != null)
                {
                    report.Add("Type", reader["Type"].ToString());
                    report.Add("Command", reader["Command"].ToString());
                    report.Add("Title", reader["Title"].ToString());
                    report.Add("Library", reader["Library"].ToString());
                    report.Add("Item", reader["Item"].ToString());
                    report.Add("Other", reader["Other"].ToString());

                    reportItems.Add(report);
                }
                else
                {
                    MessageBox.Show("Failure executing query for " + domainCode + " item " + reader["Item"].ToString() + ". Please contact technical support.", "Failure Running Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            reader.Close();

            progressBar.Invoke(new MethodInvoker(delegate { progressBar.Value = 10; }));

            int row = 0;
            if (reportItems.Count > 0)
            {
                foreach (Dictionary<string, string> report in reportItems)
                {
                    ITableLayoutRowItem rowItem = factory.NewReport(yearTermCode, report, ref _sqlConn);

                    tablePanel.Invoke(new MethodInvoker(delegate
                    {
                        tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
                        tablePanel.Controls.Add(rowItem.ControlAt(0), 0, row);
                        tablePanel.Controls.Add(rowItem.ControlAt(1), 1, row);
                        tablePanel.Controls.Add(rowItem.ControlAt(2), 2, row);
                        tablePanel.Controls.Add(rowItem.ControlAt(3), 3, row);
                    }));
                    row++;

                    progressBar.Invoke(new MethodInvoker(delegate { progressBar.Value = 10 + ((90 / reportItems.Count) * row); }));
                }
            }
            else
            {
                MessageBox.Show("No " + domainCode + " verification reports were found or processed in database. Please contact technical support for more information.", "No Available Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Add bottom spacer and set final layout.
            tablePanel.Invoke(new MethodInvoker(delegate
            {
                tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tablePanel.RowCount = ++row;
                tablePanel.PerformLayout();
                tablePanel.VerticalScroll.Enabled = true;
                tablePanel.VerticalScroll.Visible = true;
                tablePanel.HorizontalScroll.Enabled = false;
                tablePanel.HorizontalScroll.Visible = false;
                tablePanel.Refresh();
            }));
        }
    }
}
