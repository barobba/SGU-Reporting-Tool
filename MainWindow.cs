using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAKISVerify_Click(object sender, EventArgs e)
        {
            // TODO: Lock out UI while worker thread is doing its thing.
            backgroundWorkerAKIS.RunWorkerAsync();
        }

        private void buttonIPEDVerify_Click(object sender, EventArgs e)
        {
            // TODO: Lock out UI while worker thread is doing its thing.
            backgroundWorkerIPED.RunWorkerAsync();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // TODO: Populate the year/semester selection drop down.
        }

        private void backgroundWorkerAKIS_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Program.TryMakeSQLConnection())
                return;

            // Enable spinner, dis-engage verify button.
            pictureBoxAKISSpinner.Enabled = true;
            pictureBoxAKISSpinner.Visible = true;
            buttonIPEDVerify.Enabled = false;
            // TODO: Disable yr/sem drop down (has to work with other threads).

            // FIXME: Implement the drop down for available dates and grab it here.
            Program.RunAKISVerify("201020", ref tableLayoutPanelAKIS);

            // Disable spinner, re-engage verify button.
            pictureBoxAKISSpinner.Enabled = false;
            pictureBoxAKISSpinner.Visible = false;
            buttonIPEDVerify.Enabled = true;
            // TODO: Enable yr/sem drop down (has to work with other threads).
        }

        private void backgroundWorkerIPED_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Program.TryMakeSQLConnection())
                return;

            // Enable spinner, dis-engage verify button.
            pictureBoxIPEDSpinner.Enabled = true;
            pictureBoxIPEDSpinner.Visible = true;
            buttonIPEDVerify.Enabled = false;
            // TODO: Disable yr/sem drop down (has to work with other threads).

            // FIXME: Implement the drop down for available dates and grab it here.
            Program.RunIPEDVerify("201020", ref tableLayoutPanelIPED);

            // Disable spinner, re-engage verify button.
            pictureBoxIPEDSpinner.Enabled = false;
            pictureBoxIPEDSpinner.Visible = false;
            buttonIPEDVerify.Enabled = true;
            // TODO: Enable yr/sem drop down (has to work with other threads).
        }
    }
}
