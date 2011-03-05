namespace SGU_Reporting_Tool
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAKIS = new System.Windows.Forms.TabPage();
            this.pictureBoxAKISSpinner = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelAKIS = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAKISVerify = new System.Windows.Forms.Button();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxGeneralSpinner = new System.Windows.Forms.PictureBox();
            this.buttonGeneralVerify = new System.Windows.Forms.Button();
            this.comboBoxYearTerm = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerAKIS = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGeneral = new System.ComponentModel.BackgroundWorker();
            this.labelYearTerm = new System.Windows.Forms.Label();
            this.progressBarAKIS = new System.Windows.Forms.ProgressBar();
            this.labelAKISRun = new System.Windows.Forms.Label();
            this.labelGeneralRun = new System.Windows.Forms.Label();
            this.progressBarGeneral = new System.Windows.Forms.ProgressBar();
            this.tabControlMain.SuspendLayout();
            this.tabPageAKIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAKISSpinner)).BeginInit();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGeneralSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlMain.Controls.Add(this.tabPageAKIS);
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Location = new System.Drawing.Point(12, 39);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(450, 430);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageAKIS
            // 
            this.tabPageAKIS.Controls.Add(this.tableLayoutPanelAKIS);
            this.tabPageAKIS.Controls.Add(this.labelAKISRun);
            this.tabPageAKIS.Controls.Add(this.pictureBoxAKISSpinner);
            this.tabPageAKIS.Controls.Add(this.progressBarAKIS);
            this.tabPageAKIS.Controls.Add(this.buttonAKISVerify);
            this.tabPageAKIS.Location = new System.Drawing.Point(4, 25);
            this.tabPageAKIS.Name = "tabPageAKIS";
            this.tabPageAKIS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAKIS.Size = new System.Drawing.Size(442, 401);
            this.tabPageAKIS.TabIndex = 0;
            this.tabPageAKIS.Text = "AKIS";
            this.tabPageAKIS.UseVisualStyleBackColor = true;
            // 
            // pictureBoxAKISSpinner
            // 
            this.pictureBoxAKISSpinner.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBoxAKISSpinner.Enabled = false;
            this.pictureBoxAKISSpinner.Image = global::SGU_Reporting_Tool.Properties.Resources.ajax_activity_indicators_download_bigrotation2;
            this.pictureBoxAKISSpinner.InitialImage = null;
            this.pictureBoxAKISSpinner.Location = new System.Drawing.Point(197, 141);
            this.pictureBoxAKISSpinner.Name = "pictureBoxAKISSpinner";
            this.pictureBoxAKISSpinner.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxAKISSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAKISSpinner.TabIndex = 2;
            this.pictureBoxAKISSpinner.TabStop = false;
            // 
            // tableLayoutPanelAKIS
            // 
            this.tableLayoutPanelAKIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelAKIS.AutoScroll = true;
            this.tableLayoutPanelAKIS.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelAKIS.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanelAKIS.ColumnCount = 4;
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAKIS.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanelAKIS.Name = "tableLayoutPanelAKIS";
            this.tableLayoutPanelAKIS.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tableLayoutPanelAKIS.RowCount = 1;
            this.tableLayoutPanelAKIS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 359F));
            this.tableLayoutPanelAKIS.Size = new System.Drawing.Size(430, 343);
            this.tableLayoutPanelAKIS.TabIndex = 1;
            // 
            // buttonAKISVerify
            // 
            this.buttonAKISVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAKISVerify.Location = new System.Drawing.Point(316, 6);
            this.buttonAKISVerify.Name = "buttonAKISVerify";
            this.buttonAKISVerify.Size = new System.Drawing.Size(120, 40);
            this.buttonAKISVerify.TabIndex = 0;
            this.buttonAKISVerify.Text = "&Run Verifications";
            this.buttonAKISVerify.UseVisualStyleBackColor = true;
            this.buttonAKISVerify.Click += new System.EventHandler(this.buttonAKISVerify_Click);
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);
            this.tabPageGeneral.Controls.Add(this.labelGeneralRun);
            this.tabPageGeneral.Controls.Add(this.progressBarGeneral);
            this.tabPageGeneral.Controls.Add(this.pictureBoxGeneralSpinner);
            this.tabPageGeneral.Controls.Add(this.buttonGeneralVerify);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(442, 401);
            this.tabPageGeneral.TabIndex = 1;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneral
            // 
            this.tableLayoutPanelGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelGeneral.AutoScroll = true;
            this.tableLayoutPanelGeneral.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelGeneral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanelGeneral.ColumnCount = 4;
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanelGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeneral.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanelGeneral.Name = "tableLayoutPanelGeneral";
            this.tableLayoutPanelGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tableLayoutPanelGeneral.RowCount = 1;
            this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 359F));
            this.tableLayoutPanelGeneral.Size = new System.Drawing.Size(430, 343);
            this.tableLayoutPanelGeneral.TabIndex = 4;
            // 
            // pictureBoxGeneralSpinner
            // 
            this.pictureBoxGeneralSpinner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxGeneralSpinner.Enabled = false;
            this.pictureBoxGeneralSpinner.Image = global::SGU_Reporting_Tool.Properties.Resources.ajax_activity_indicators_download_bigrotation2;
            this.pictureBoxGeneralSpinner.InitialImage = null;
            this.pictureBoxGeneralSpinner.Location = new System.Drawing.Point(197, 141);
            this.pictureBoxGeneralSpinner.Name = "pictureBoxGeneralSpinner";
            this.pictureBoxGeneralSpinner.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxGeneralSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxGeneralSpinner.TabIndex = 3;
            this.pictureBoxGeneralSpinner.TabStop = false;
            // 
            // buttonGeneralVerify
            // 
            this.buttonGeneralVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGeneralVerify.Location = new System.Drawing.Point(316, 6);
            this.buttonGeneralVerify.Name = "buttonGeneralVerify";
            this.buttonGeneralVerify.Size = new System.Drawing.Size(120, 40);
            this.buttonGeneralVerify.TabIndex = 0;
            this.buttonGeneralVerify.Text = "&Run Verifications";
            this.buttonGeneralVerify.UseVisualStyleBackColor = true;
            this.buttonGeneralVerify.Click += new System.EventHandler(this.buttonGeneralVerify_Click);
            // 
            // comboBoxYearTerm
            // 
            this.comboBoxYearTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxYearTerm.FormattingEnabled = true;
            this.comboBoxYearTerm.Location = new System.Drawing.Point(312, 12);
            this.comboBoxYearTerm.Name = "comboBoxYearTerm";
            this.comboBoxYearTerm.Size = new System.Drawing.Size(150, 21);
            this.comboBoxYearTerm.TabIndex = 3;
            // 
            // backgroundWorkerAKIS
            // 
            this.backgroundWorkerAKIS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAKIS_DoWork);
            // 
            // backgroundWorkerGeneral
            // 
            this.backgroundWorkerGeneral.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGeneral_DoWork);
            // 
            // labelYearTerm
            // 
            this.labelYearTerm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelYearTerm.AutoSize = true;
            this.labelYearTerm.Location = new System.Drawing.Point(198, 15);
            this.labelYearTerm.Name = "labelYearTerm";
            this.labelYearTerm.Size = new System.Drawing.Size(108, 13);
            this.labelYearTerm.TabIndex = 4;
            this.labelYearTerm.Text = "Year/Term Selection:";
            // 
            // progressBarAKIS
            // 
            this.progressBarAKIS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressBarAKIS.Location = new System.Drawing.Point(156, 200);
            this.progressBarAKIS.Name = "progressBarAKIS";
            this.progressBarAKIS.Size = new System.Drawing.Size(120, 23);
            this.progressBarAKIS.TabIndex = 3;
            // 
            // labelAKISRun
            // 
            this.labelAKISRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelAKISRun.AutoSize = true;
            this.labelAKISRun.Location = new System.Drawing.Point(135, 184);
            this.labelAKISRun.Name = "labelAKISRun";
            this.labelAKISRun.Size = new System.Drawing.Size(170, 13);
            this.labelAKISRun.TabIndex = 4;
            this.labelAKISRun.Text = "Please wait while running reports...";
            // 
            // labelGeneralRun
            // 
            this.labelGeneralRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelGeneralRun.AutoSize = true;
            this.labelGeneralRun.Location = new System.Drawing.Point(135, 184);
            this.labelGeneralRun.Name = "labelGeneralRun";
            this.labelGeneralRun.Size = new System.Drawing.Size(170, 13);
            this.labelGeneralRun.TabIndex = 7;
            this.labelGeneralRun.Text = "Please wait while running reports...";
            // 
            // progressBarGeneral
            // 
            this.progressBarGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressBarGeneral.Location = new System.Drawing.Point(156, 200);
            this.progressBarGeneral.Name = "progressBarGeneral";
            this.progressBarGeneral.Size = new System.Drawing.Size(120, 23);
            this.progressBarGeneral.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 481);
            this.Controls.Add(this.labelYearTerm);
            this.Controls.Add(this.comboBoxYearTerm);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SGU Reporting Tool";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAKIS.ResumeLayout(false);
            this.tabPageAKIS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAKISSpinner)).EndInit();
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGeneralSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageAKIS;
        private System.Windows.Forms.Button buttonAKISVerify;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Button buttonGeneralVerify;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAKIS;
        private System.Windows.Forms.PictureBox pictureBoxAKISSpinner;
        private System.Windows.Forms.PictureBox pictureBoxGeneralSpinner;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAKIS;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGeneral;
        private System.Windows.Forms.ComboBox comboBoxYearTerm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
        private System.Windows.Forms.Label labelYearTerm;
        private System.Windows.Forms.Label labelAKISRun;
        private System.Windows.Forms.ProgressBar progressBarAKIS;
        private System.Windows.Forms.Label labelGeneralRun;
        private System.Windows.Forms.ProgressBar progressBarGeneral;
    }
}

