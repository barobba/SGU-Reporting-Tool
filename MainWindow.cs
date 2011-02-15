﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;


namespace SGU_Reporting_Tool
{
    public partial class MainWindow : Form
    {
        public const int TableLayoutRowHeight = 50;
        private bool _hasSQLConnMade = false;
        private SqlConnection _sqlConn = null;
        private SecureString _sqlConnUsername = null;
        private SecureString _sqlConnPassword = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool tryMakeSQLConnection()
        {
            if (_hasSQLConnMade)
                return true;

            CredentialsWindow window = new CredentialsWindow();
            if (DialogResult.OK != window.ShowDialog())
                return false;
            _sqlConnUsername = window.Username;
            _sqlConnPassword = window.Password;

            _sqlConn = new SqlConnection("user id=" + _sqlConnUsername.ToString() + ";" +
                                         "password=" + _sqlConnPassword.ToString() + ";" +
                                         "server=jenzabardb;" +
                                         "Trusted_Connection=yes;" +
                                         "database=TmsEPly; " +
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

        private void buttonAKISVerify_Click(object sender, EventArgs e)
        {

        }

        private void buttonIPEDVerify_Click(object sender, EventArgs e)
        {

        }

        private void buttonAKISLayout_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                Console.Write(btn.Tag);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Delete current contents
            tableLayoutPanelAKIS.Controls.Clear();
            tableLayoutPanelAKIS.RowStyles.Clear();
            tableLayoutPanelIPED.Controls.Clear();
            tableLayoutPanelIPED.RowStyles.Clear();
            
            int row = tableLayoutPanelAKIS.Controls.Count;
            // Temporary code to insert a few controls into the table view

            Random rnd = new Random();

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            Label lbl = new Label();
            lbl.Text = "Testing 1";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            DisplayChart chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            Button btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 2";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 3";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 4";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 5";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 6";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.Absolute, TableLayoutRowHeight));
            lbl = new Label();
            lbl.Text = "Testing 7";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            tableLayoutPanelAKIS.Controls.Add(lbl, 0, row);
            chrt = new DisplayChart();
            chrt.MinValue = 0.0;
            chrt.MaxValue = 100.0;
            chrt.CurrentValue = rnd.NextDouble() * 100.0;
            tableLayoutPanelAKIS.Controls.Add(chrt, 1, row);
            btn = new Button();
            btn.Text = "Perform";
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Dock = DockStyle.Fill;
            btn.BackColor = SystemColors.Control;
            btn.Tag = row;
            btn.Click += new System.EventHandler(buttonAKISLayout_Click);
            tableLayoutPanelAKIS.Controls.Add(btn, 2, row);
            row++;

            tableLayoutPanelAKIS.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanelAKIS.RowCount = ++row;

            tableLayoutPanelAKIS.PerformLayout();
            

            //tableLayoutPanelAKIS.AutoScroll = false;
            // Turn off horizontal scrolling on table layouts
            //tableLayoutPanelAKIS.Scroll
            tableLayoutPanelAKIS.VerticalScroll.Enabled = true;
            tableLayoutPanelAKIS.VerticalScroll.Visible = true;
            tableLayoutPanelAKIS.HorizontalScroll.Enabled = false;
            tableLayoutPanelAKIS.HorizontalScroll.Visible = false;
        }
    }
}
