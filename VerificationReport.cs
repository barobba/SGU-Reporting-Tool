using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    class VerificationReport : ITableLayoutRowItem
    {
        private string _rTitle = null;
        private int _numMiss;
        private int _numTotal;
        private string _rLib = null;
        private string _rItem = null;

        public VerificationReport(string reportTitle, int numMissing, int numTotal, string reportLibrary, string reportItem)
        {
            _rTitle = reportTitle;
            _numMiss = numMissing;
            _numTotal = numTotal;
            _rLib = reportLibrary;
            _rItem = reportItem;
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            // Open new info maker window with report item.
            string args = "/P report /L " + _rLib + " /O " + _rItem + " /RO";
            ProcessStartInfo procStartInfo = new ProcessStartInfo(Program.InfoMakerExecLocation, args);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        public Control ControlAt(int column)
        {
            switch (column)
            {
                case 0:
                    {
                        Label lbl = new Label();
                        lbl.Text = _rTitle;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Dock = DockStyle.Fill;

                        return lbl;
                    }

                case 1:
                    {
                        DisplayChart chrt = new DisplayChart();
                        chrt.MinValue = 0.0;
                        chrt.MaxValue = _numTotal;
                        chrt.CurrentValue = _numTotal - _numMiss;

                        return chrt;
                    }

                case 2:
                    {
                        Button btn = new Button();
                        btn.Text = "Open Verification";
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        btn.Dock = DockStyle.Fill;
                        btn.BackColor = SystemColors.Control;
                        btn.Tag = _rLib + ";" + _rItem;
                        btn.Click += new System.EventHandler(this.buttonReport_Click);

                        return btn;
                    }
            }

            return null;
        }
    }
}
