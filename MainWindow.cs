using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    public partial class MainWindow : Form
    {
        private static int _numVersRunning = 0;
        private static Mutex _numVersLock = new Mutex(false);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAKISVerify_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerAKIS.IsBusy)
                backgroundWorkerAKIS.RunWorkerAsync();
        }

        private void buttonGeneralVerify_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerGeneral.IsBusy)
                backgroundWorkerGeneral.RunWorkerAsync();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Try to get the layouts to not show the horizontal scroll bar by default.
            tableLayoutPanelAKIS.PerformLayout();
            tableLayoutPanelGeneral.PerformLayout();

            // Populate the year/semester selection drop down.
            int year = 2005;
            int yearNext = year + 1;
            while (year <= DateTime.Today.Year)
            {
                comboBoxYearTerm.Items.Add("Fall, " + year.ToString() + " (" + year.ToString() + "10)");
                comboBoxYearTerm.Items.Add("Spring, " + yearNext.ToString() + " (" + year.ToString() + "20)");
                if (year <= 2007)
                {
                    comboBoxYearTerm.Items.Add("Summer #1, " + yearNext.ToString() + " (" + year.ToString() + "30)");
                    comboBoxYearTerm.Items.Add("Summer #2, " + yearNext.ToString() + " (" + year.ToString() + "40)");
                }
                else
                {
                    comboBoxYearTerm.Items.Add("Summer, " + yearNext.ToString() + " (" + year.ToString() + "50)");
                }

                year++;
                yearNext++;
            }

            comboBoxYearTerm.SelectedIndex = comboBoxYearTerm.Items.Count - 6;
        }

        private void backgroundWorkerAKIS_DoWork(object sender, DoWorkEventArgs e)
        {
            // Enable spinner, dis-engage verify button, dis-engage yr/sem drop down.
            tableLayoutPanelAKIS.Invoke(new MethodInvoker(delegate {
                pictureBoxAKISSpinner.Enabled = true;
                progressBarAKIS.Value = 0;
                tableLayoutPanelAKIS.Visible = false;
                buttonAKISVerify.Enabled = false;
            }));
            _numVersLock.WaitOne();
            if (_numVersRunning++ == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = false; }));
            _numVersLock.ReleaseMutex();

            DialogResult rslt = Program.TryMakeSQLConnection();
            if (DialogResult.OK == rslt)
            {
                string yearTermCode = "";
                ComboBox comboBox = comboBoxYearTerm;
                comboBox.Invoke(new MethodInvoker(delegate
                {
                    string itemStr = (comboBox.SelectedItem as string);
                    yearTermCode = itemStr.Substring(itemStr.Length - 7, 6);
                }));
                Program.RunVerify("AKIS", yearTermCode, tableLayoutPanelAKIS, progressBarAKIS);
            }
            else if(DialogResult.Abort == rslt)
            {
                MessageBox.Show("Cannot connect to the main Jenzabar database server.", "Failure Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Disable spinner, re-engage verify button, re-engage yr/sem drop down.
            tableLayoutPanelAKIS.Invoke(new MethodInvoker(delegate
            {
                pictureBoxAKISSpinner.Enabled = false;
                progressBarAKIS.Value = 100;
                tableLayoutPanelAKIS.Visible = true;
                buttonAKISVerify.Enabled = true;
            }));
            _numVersLock.WaitOne();
            if (--_numVersRunning == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = true; }));
            _numVersLock.ReleaseMutex();
        }

        private void backgroundWorkerGeneral_DoWork(object sender, DoWorkEventArgs e)
        {
            // Enable spinner, dis-engage verify button, dis-engage yr/sem drop down.
            tableLayoutPanelGeneral.Invoke(new MethodInvoker(delegate
            {
                pictureBoxGeneralSpinner.Enabled = true;
                progressBarGeneral.Value = 0;
                tableLayoutPanelGeneral.Visible = false;
                buttonGeneralVerify.Enabled = false;
            }));
            _numVersLock.WaitOne();
            if (_numVersRunning++ == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = false; }));
            _numVersLock.ReleaseMutex();

            DialogResult rslt = Program.TryMakeSQLConnection();
            if (DialogResult.OK == rslt)
            {
                string yearTermCode = "";
                ComboBox comboBox = comboBoxYearTerm;
                comboBox.Invoke(new MethodInvoker(delegate
                {
                    string itemStr = (comboBox.SelectedItem as string);
                    yearTermCode = itemStr.Substring(itemStr.Length - 7, 6);
                }));
                Program.RunVerify("General", yearTermCode, tableLayoutPanelGeneral, progressBarGeneral);
            }
            else if (DialogResult.Abort == rslt)
            {
                MessageBox.Show("Cannot connect to the main Jenzabar database server.", "Failure Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Disable spinner, re-engage verify button, re-engage yr/sem drop down.
            tableLayoutPanelGeneral.Invoke(new MethodInvoker(delegate
            {
                pictureBoxGeneralSpinner.Enabled = false;
                progressBarGeneral.Value = 100;
                tableLayoutPanelGeneral.Visible = true;
                buttonGeneralVerify.Enabled = true;
            }));
            _numVersLock.WaitOne();
            if (--_numVersRunning == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = true; }));
            _numVersLock.ReleaseMutex();
        }
    }
}
