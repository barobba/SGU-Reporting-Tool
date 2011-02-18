using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        public const string TableStudTermSumDiv = "stud_term_sum_div";
        public const string InfoMakerExecKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\im115.exe";

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
            _infoMakerExecLoc = rk.GetValue(InfoMakerExecKey).ToString();

            Application.Run(new MainWindow());
        }

        public static string InfoMakerExecLocation
        {
            get { return _infoMakerExecLoc; }
        }

        public static bool TryMakeSQLConnection()
        {
            if (_hasSQLConnMade)
                return true;

            CredentialsWindow window = new CredentialsWindow();
            if (DialogResult.OK != window.ShowDialog())
                return false;

            // U/n p/w in a read-only secured string at this point.
            _sqlConnUsername = window.Username;
            _sqlConnPassword = window.Password;

            _sqlConn = new SqlConnection("user id=" + _sqlConnUsername.ToString() + ";" +
                                         "password=" + _sqlConnPassword.ToString() + ";" +
                                         "server=" + WorkingServer + ";" +
                                         "Trusted_Connection=yes;" +
                                         "database=" + WorkingDB + "; " +
                                         "connection timeout=30");
            try
            {
                _sqlConn.Open();
            }
            catch
            {
                return false;
            }

            _hasSQLConnMade = true;
            return true;
        }

        public static void RunAKISVerify(string yearTermCode, ref TableLayoutPanel tableLayoutPanelAKIS)
        {
            // Prep report factory for correct student totals.
            ReportFactory factory = new ReportFactory();
            factory.GetTotalStudentCount(yearTermCode, ref _sqlConn);

            // Delete current contents.
            tableLayoutPanelAKIS.Controls.Clear();
            tableLayoutPanelAKIS.RowStyles.Clear();

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
                tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
                tableLayoutPanelAKIS.Controls.Add(rowItem.ControlAt(0), 0, row);
                tableLayoutPanelAKIS.Controls.Add(rowItem.ControlAt(1), 1, row);
                tableLayoutPanelAKIS.Controls.Add(rowItem.ControlAt(2), 2, row);
                row++;
            }

            // Add bottom spacer and set final layout.
            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAKIS.RowCount = ++row;
            tableLayoutPanelAKIS.PerformLayout();
            tableLayoutPanelAKIS.VerticalScroll.Enabled = true;
            tableLayoutPanelAKIS.VerticalScroll.Visible = true;
            tableLayoutPanelAKIS.HorizontalScroll.Enabled = false;
            tableLayoutPanelAKIS.HorizontalScroll.Visible = false;
        }

        public static void RunIPEDVerify(string yearTermCode, ref TableLayoutPanel tableLayoutPanelIPED)
        {
            // Prep report factory for correct student totals.
            ReportFactory factory = new ReportFactory();
            factory.GetTotalStudentCount(yearTermCode, ref _sqlConn);

            // Delete current contents.
            tableLayoutPanelIPED.Controls.Clear();
            tableLayoutPanelIPED.RowStyles.Clear();

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
                tableLayoutPanelIPED.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
                tableLayoutPanelIPED.Controls.Add(rowItem.ControlAt(0), 0, row);
                tableLayoutPanelIPED.Controls.Add(rowItem.ControlAt(1), 1, row);
                tableLayoutPanelIPED.Controls.Add(rowItem.ControlAt(2), 2, row);
                row++;
            }

            // Add bottom spacer and set final layout.
            tableLayoutPanelIPED.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelIPED.RowCount = ++row;
            tableLayoutPanelIPED.PerformLayout();
            tableLayoutPanelIPED.VerticalScroll.Enabled = true;
            tableLayoutPanelIPED.VerticalScroll.Visible = true;
            tableLayoutPanelIPED.HorizontalScroll.Enabled = false;
            tableLayoutPanelIPED.HorizontalScroll.Visible = false;
        }
    }
}
