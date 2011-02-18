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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAKIS = new System.Windows.Forms.TabPage();
            this.pictureBoxAKISSpinner = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelAKIS = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAKISVerify = new System.Windows.Forms.Button();
            this.tabPageIPED = new System.Windows.Forms.TabPage();
            this.pictureBoxIPEDSpinner = new System.Windows.Forms.PictureBox();
            this.buttonIPEDVerify = new System.Windows.Forms.Button();
            this.comboBoxAKISDate = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerAKIS = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerIPED = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanelIPED = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlMain.SuspendLayout();
            this.tabPageAKIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAKISSpinner)).BeginInit();
            this.tabPageIPED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIPEDSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlMain.Controls.Add(this.tabPageAKIS);
            this.tabControlMain.Controls.Add(this.tabPageIPED);
            this.tabControlMain.Location = new System.Drawing.Point(12, 39);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(450, 430);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageAKIS
            // 
            this.tabPageAKIS.Controls.Add(this.pictureBoxAKISSpinner);
            this.tabPageAKIS.Controls.Add(this.tableLayoutPanelAKIS);
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
            this.pictureBoxAKISSpinner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxAKISSpinner.Enabled = false;
            this.pictureBoxAKISSpinner.Image = global::SGU_Reporting_Tool.Properties.Resources.ajax_activity_indicators_download_bigrotation2;
            this.pictureBoxAKISSpinner.InitialImage = null;
            this.pictureBoxAKISSpinner.Location = new System.Drawing.Point(270, 6);
            this.pictureBoxAKISSpinner.Name = "pictureBoxAKISSpinner";
            this.pictureBoxAKISSpinner.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxAKISSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAKISSpinner.TabIndex = 2;
            this.pictureBoxAKISSpinner.TabStop = false;
            this.pictureBoxAKISSpinner.Visible = false;
            // 
            // tableLayoutPanelAKIS
            // 
            this.tableLayoutPanelAKIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelAKIS.AutoScroll = true;
            this.tableLayoutPanelAKIS.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelAKIS.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanelAKIS.ColumnCount = 3;
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelAKIS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAKIS.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanelAKIS.Name = "tableLayoutPanelAKIS";
            this.tableLayoutPanelAKIS.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tableLayoutPanelAKIS.RowCount = 1;
            this.tableLayoutPanelAKIS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
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
            // tabPageIPED
            // 
            this.tabPageIPED.Controls.Add(this.tableLayoutPanelIPED);
            this.tabPageIPED.Controls.Add(this.pictureBoxIPEDSpinner);
            this.tabPageIPED.Controls.Add(this.buttonIPEDVerify);
            this.tabPageIPED.Location = new System.Drawing.Point(4, 25);
            this.tabPageIPED.Name = "tabPageIPED";
            this.tabPageIPED.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPED.Size = new System.Drawing.Size(442, 401);
            this.tabPageIPED.TabIndex = 1;
            this.tabPageIPED.Text = "IPED";
            this.tabPageIPED.UseVisualStyleBackColor = true;
            // 
            // pictureBoxIPEDSpinner
            // 
            this.pictureBoxIPEDSpinner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBoxIPEDSpinner.Enabled = false;
            this.pictureBoxIPEDSpinner.Image = global::SGU_Reporting_Tool.Properties.Resources.ajax_activity_indicators_download_bigrotation2;
            this.pictureBoxIPEDSpinner.InitialImage = null;
            this.pictureBoxIPEDSpinner.Location = new System.Drawing.Point(270, 6);
            this.pictureBoxIPEDSpinner.Name = "pictureBoxIPEDSpinner";
            this.pictureBoxIPEDSpinner.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxIPEDSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIPEDSpinner.TabIndex = 3;
            this.pictureBoxIPEDSpinner.TabStop = false;
            this.pictureBoxIPEDSpinner.Visible = false;
            // 
            // buttonIPEDVerify
            // 
            this.buttonIPEDVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIPEDVerify.Location = new System.Drawing.Point(316, 6);
            this.buttonIPEDVerify.Name = "buttonIPEDVerify";
            this.buttonIPEDVerify.Size = new System.Drawing.Size(120, 40);
            this.buttonIPEDVerify.TabIndex = 0;
            this.buttonIPEDVerify.Text = "&Run Verifications";
            this.buttonIPEDVerify.UseVisualStyleBackColor = true;
            this.buttonIPEDVerify.Click += new System.EventHandler(this.buttonIPEDVerify_Click);
            // 
            // comboBoxAKISDate
            // 
            this.comboBoxAKISDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxAKISDate.FormattingEnabled = true;
            this.comboBoxAKISDate.Location = new System.Drawing.Point(12, 12);
            this.comboBoxAKISDate.Name = "comboBoxAKISDate";
            this.comboBoxAKISDate.Size = new System.Drawing.Size(150, 21);
            this.comboBoxAKISDate.TabIndex = 3;
            // 
            // backgroundWorkerAKIS
            // 
            this.backgroundWorkerAKIS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAKIS_DoWork);
            // 
            // backgroundWorkerIPED
            // 
            this.backgroundWorkerIPED.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerIPED_DoWork);
            // 
            // tableLayoutPanelIPED
            // 
            this.tableLayoutPanelIPED.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelIPED.AutoScroll = true;
            this.tableLayoutPanelIPED.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelIPED.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanelIPED.ColumnCount = 3;
            this.tableLayoutPanelIPED.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelIPED.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelIPED.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelIPED.Location = new System.Drawing.Point(6, 52);
            this.tableLayoutPanelIPED.Name = "tableLayoutPanelIPED";
            this.tableLayoutPanelIPED.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tableLayoutPanelIPED.RowCount = 1;
            this.tableLayoutPanelIPED.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanelIPED.Size = new System.Drawing.Size(430, 343);
            this.tableLayoutPanelIPED.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 481);
            this.Controls.Add(this.comboBoxAKISDate);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "SGU Reporting Tool";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAKIS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAKISSpinner)).EndInit();
            this.tabPageIPED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIPEDSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageAKIS;
        private System.Windows.Forms.Button buttonAKISVerify;
        private System.Windows.Forms.TabPage tabPageIPED;
        private System.Windows.Forms.Button buttonIPEDVerify;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAKIS;
        private System.Windows.Forms.PictureBox pictureBoxAKISSpinner;
        private System.Windows.Forms.PictureBox pictureBoxIPEDSpinner;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAKIS;
        private System.ComponentModel.BackgroundWorker backgroundWorkerIPED;
        private System.Windows.Forms.ComboBox comboBoxAKISDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIPED;
    }
}

