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
        public const string WorkingDB = "TmsEPly";
        public const string ReportTable = "VerfToolReports";
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
            object rkValue = rk.GetValue(InfoMakerExecKey);

            if (rkValue != null)
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

        public static void RunAKISVerify(string yearTermCode, ref TableLayoutPanel tableLayoutPanelAKIS)
        {
            // Need a local for the clojure below.
            TableLayoutPanel panel = tableLayoutPanelAKIS;

            // Prep report factory for correct student totals.
            ReportFactory factory = new ReportFactory();
            factory.GetTotalStudentCount(yearTermCode, ref _sqlConn);

            // Delete current contents.
            panel.Invoke(new MethodInvoker(delegate
            {
                panel.Controls.Clear();
                panel.RowStyles.Clear();
            }));

            // Grab reports listing.
            string sqlCmdStr = "SELECT * FROM [" + WorkingDB + "].[dbo].[" +
                ReportTable + "] WHERE ReportDomain is \"AKIS\";";
            SqlCommand sqlCmd = new SqlCommand(sqlCmdStr);
            sqlCmd.Connection = _sqlConn;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            int row = 0;
            while (reader.Read())
            {
                ITableLayoutRowItem rowItem = factory.NewReport(ref reader, ref _sqlConn);

                panel.Invoke(new MethodInvoker(delegate
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
                    panel.Controls.Add(rowItem.ControlAt(0), 0, row);
                    panel.Controls.Add(rowItem.ControlAt(1), 1, row);
                    panel.Controls.Add(rowItem.ControlAt(2), 2, row);
                }));
                row++;
            }

            reader.Close();

            // Add bottom spacer and set final layout.
            panel.Invoke(new MethodInvoker(delegate
            {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                panel.RowCount = ++row;
                panel.PerformLayout();
                panel.VerticalScroll.Enabled = true;
                panel.VerticalScroll.Visible = true;
                panel.HorizontalScroll.Enabled = false;
                panel.HorizontalScroll.Visible = false;
            }));
        }

        public static void RunIPEDVerify(string yearTermCode, ref TableLayoutPanel tableLayoutPanelIPED)
        {
            // Need a local for the clojure below.
            TableLayoutPanel panel = tableLayoutPanelIPED;

            // Prep report factory for correct student totals.
            ReportFactory factory = new ReportFactory();
            factory.GetTotalStudentCount(yearTermCode, ref _sqlConn);

            // Delete current contents.
            panel.Invoke(new MethodInvoker(delegate
            {
                panel.Controls.Clear();
                panel.RowStyles.Clear();
            }));

            // Grab reports listing.
            string sqlCmdStr = "SELECT * FROM [" + WorkingDB + "].[dbo].[" +
                ReportTable + "] WHERE ReportDomain is \"IPED\";";
            SqlCommand sqlCmd = new SqlCommand(sqlCmdStr);
            sqlCmd.Connection = _sqlConn;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            int row = 0;
            while (reader.Read())
            {
                ITableLayoutRowItem rowItem = factory.NewReport(ref reader, ref _sqlConn);

                panel.Invoke(new MethodInvoker(delegate
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
                    panel.Controls.Add(rowItem.ControlAt(0), 0, row);
                    panel.Controls.Add(rowItem.ControlAt(1), 1, row);
                    panel.Controls.Add(rowItem.ControlAt(2), 2, row);
                }));
                row++;
            }

            reader.Close();

            // Add bottom spacer and set final layout.
            panel.Invoke(new MethodInvoker(delegate
            {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                panel.RowCount = ++row;
                panel.PerformLayout();
                panel.VerticalScroll.Enabled = true;
                panel.VerticalScroll.Visible = true;
                panel.HorizontalScroll.Enabled = false;
                panel.HorizontalScroll.Visible = false;
            }));
        }
    }
}
