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

        private void buttonIPEDVerify_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerIPED.IsBusy)
                backgroundWorkerIPED.RunWorkerAsync();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tableLayoutPanelAKIS.PerformLayout();
            tableLayoutPanelIPED.PerformLayout();

            // TODO: Populate the year/semester selection drop down.
        }

        private void backgroundWorkerAKIS_DoWork(object sender, DoWorkEventArgs e)
        {
            // Enable spinner, dis-engage verify button, dis-engage yr/sem drop down.
            pictureBoxAKISSpinner.Invoke(new MethodInvoker(delegate { pictureBoxAKISSpinner.Enabled = true; }));
            pictureBoxAKISSpinner.Invoke(new MethodInvoker(delegate { pictureBoxAKISSpinner.Visible = true; }));
            buttonAKISVerify.Invoke(new MethodInvoker(delegate { buttonAKISVerify.Enabled = false; }));
            _numVersLock.WaitOne();
            if (_numVersRunning++ == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = false; }));
            _numVersLock.ReleaseMutex();

            DialogResult rslt = Program.TryMakeSQLConnection();
            if (DialogResult.OK == rslt)
            {
                // FIXME: Implement the drop down for available dates and grab it here.
                Program.RunAKISVerify("201020", ref tableLayoutPanelAKIS);
            }
            else if(DialogResult.Abort == rslt)
            {
                MessageBox.Show("Cannot connect to the main Jenzabar database server.", "Failure Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Disable spinner, re-engage verify button, re-engage yr/sem drop down.
            pictureBoxAKISSpinner.Invoke(new MethodInvoker(delegate { pictureBoxAKISSpinner.Enabled = false; }));
            pictureBoxAKISSpinner.Invoke(new MethodInvoker(delegate { pictureBoxAKISSpinner.Visible = false; }));
            buttonAKISVerify.Invoke(new MethodInvoker(delegate { buttonAKISVerify.Enabled = true; }));
            _numVersLock.WaitOne();
            if (--_numVersRunning == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = true; }));
            _numVersLock.ReleaseMutex();
        }

        private void backgroundWorkerIPED_DoWork(object sender, DoWorkEventArgs e)
        {
            // Enable spinner, dis-engage verify button, dis-engage yr/sem drop down.
            pictureBoxIPEDSpinner.Invoke(new MethodInvoker(delegate { pictureBoxIPEDSpinner.Enabled = true; }));
            pictureBoxIPEDSpinner.Invoke(new MethodInvoker(delegate { pictureBoxIPEDSpinner.Visible = true; }));
            buttonIPEDVerify.Invoke(new MethodInvoker(delegate { buttonIPEDVerify.Enabled = false; }));
            _numVersLock.WaitOne();
            if (_numVersRunning++ == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = false; }));
            _numVersLock.ReleaseMutex();

            DialogResult rslt = Program.TryMakeSQLConnection();
            if (DialogResult.OK == rslt)
            {
                // FIXME: Implement the drop down for available dates and grab it here.
                Program.RunIPEDVerify("201020", ref tableLayoutPanelIPED);
            }
            else if (DialogResult.Abort == rslt)
            {
                MessageBox.Show("Cannot connect to the main Jenzabar database server.", "Failure Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Disable spinner, re-engage verify button, re-engage yr/sem drop down.
            pictureBoxIPEDSpinner.Invoke(new MethodInvoker(delegate { pictureBoxIPEDSpinner.Enabled = false; }));
            pictureBoxIPEDSpinner.Invoke(new MethodInvoker(delegate { pictureBoxIPEDSpinner.Visible = false; }));
            buttonIPEDVerify.Invoke(new MethodInvoker(delegate { buttonIPEDVerify.Enabled = true; }));
            _numVersLock.WaitOne();
            if (--_numVersRunning == 0)
                comboBoxYearTerm.Invoke(new MethodInvoker(delegate { comboBoxYearTerm.Enabled = true; }));
            _numVersLock.ReleaseMutex();
        }
    }
}
