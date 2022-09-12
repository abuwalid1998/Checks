namespace SimpleExerciser
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAlternatePockets = new System.Windows.Forms.CheckBox();
            this.chkShowImages = new System.Windows.Forms.CheckBox();
            this.bar1 = new System.Windows.Forms.ProgressBar();
            this.btnStopDisconnect = new System.Windows.Forms.Button();
            this.btnConnectStart = new System.Windows.Forms.Button();
            this.picLarge = new System.Windows.Forms.PictureBox();
            this.lstImageList = new System.Windows.Forms.ListBox();
            this.picFront1 = new System.Windows.Forms.PictureBox();
            this.picFront2 = new System.Windows.Forms.PictureBox();
            this.picRear1 = new System.Windows.Forms.PictureBox();
            this.picRear2 = new System.Windows.Forms.PictureBox();
            this.picSnip = new System.Windows.Forms.PictureBox();
            this.lblMicr = new System.Windows.Forms.Label();
            this.tctrl1 = new System.Windows.Forms.TabControl();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTrkBaseConfig = new System.Windows.Forms.TextBox();
            this.txtTrkBaseWrite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFront1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFront2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnip)).BeginInit();
            this.tctrl1.SuspendLayout();
            this.tabImages.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAlternatePockets);
            this.groupBox1.Controls.Add(this.chkShowImages);
            this.groupBox1.Controls.Add(this.bar1);
            this.groupBox1.Controls.Add(this.btnStopDisconnect);
            this.groupBox1.Controls.Add(this.btnConnectStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // chkAlternatePockets
            // 
            this.chkAlternatePockets.AutoSize = true;
            this.chkAlternatePockets.Location = new System.Drawing.Point(354, 23);
            this.chkAlternatePockets.Name = "chkAlternatePockets";
            this.chkAlternatePockets.Size = new System.Drawing.Size(109, 17);
            this.chkAlternatePockets.TabIndex = 4;
            this.chkAlternatePockets.Text = "&Alternate pockets";
            this.chkAlternatePockets.UseVisualStyleBackColor = true;
            // 
            // chkShowImages
            // 
            this.chkShowImages.AutoSize = true;
            this.chkShowImages.Checked = true;
            this.chkShowImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowImages.Location = new System.Drawing.Point(258, 23);
            this.chkShowImages.Name = "chkShowImages";
            this.chkShowImages.Size = new System.Drawing.Size(89, 17);
            this.chkShowImages.TabIndex = 3;
            this.chkShowImages.Text = "Show &images";
            this.chkShowImages.UseVisualStyleBackColor = true;
            // 
            // bar1
            // 
            this.bar1.Location = new System.Drawing.Point(514, 19);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(250, 23);
            this.bar1.TabIndex = 2;
            this.bar1.Visible = false;
            // 
            // btnStopDisconnect
            // 
            this.btnStopDisconnect.Location = new System.Drawing.Point(132, 19);
            this.btnStopDisconnect.Name = "btnStopDisconnect";
            this.btnStopDisconnect.Size = new System.Drawing.Size(120, 23);
            this.btnStopDisconnect.TabIndex = 1;
            this.btnStopDisconnect.Text = "&Stop and Disconnect";
            this.btnStopDisconnect.UseVisualStyleBackColor = true;
            this.btnStopDisconnect.Click += new System.EventHandler(this.btnStopDisconnect_Click);
            // 
            // btnConnectStart
            // 
            this.btnConnectStart.Location = new System.Drawing.Point(6, 19);
            this.btnConnectStart.Name = "btnConnectStart";
            this.btnConnectStart.Size = new System.Drawing.Size(120, 23);
            this.btnConnectStart.TabIndex = 0;
            this.btnConnectStart.Text = "&Connect and Start";
            this.btnConnectStart.UseVisualStyleBackColor = true;
            this.btnConnectStart.Click += new System.EventHandler(this.btnConnectStart_Click);
            // 
            // picLarge
            // 
            this.picLarge.Location = new System.Drawing.Point(132, 6);
            this.picLarge.Name = "picLarge";
            this.picLarge.Size = new System.Drawing.Size(624, 377);
            this.picLarge.TabIndex = 1;
            this.picLarge.TabStop = false;
            // 
            // lstImageList
            // 
            this.lstImageList.FormattingEnabled = true;
            this.lstImageList.Location = new System.Drawing.Point(6, 6);
            this.lstImageList.Name = "lstImageList";
            this.lstImageList.Size = new System.Drawing.Size(120, 459);
            this.lstImageList.TabIndex = 2;
            // 
            // picFront1
            // 
            this.picFront1.Location = new System.Drawing.Point(132, 389);
            this.picFront1.Name = "picFront1";
            this.picFront1.Size = new System.Drawing.Size(120, 50);
            this.picFront1.TabIndex = 3;
            this.picFront1.TabStop = false;
            // 
            // picFront2
            // 
            this.picFront2.Location = new System.Drawing.Point(258, 389);
            this.picFront2.Name = "picFront2";
            this.picFront2.Size = new System.Drawing.Size(120, 50);
            this.picFront2.TabIndex = 3;
            this.picFront2.TabStop = false;
            // 
            // picRear1
            // 
            this.picRear1.Location = new System.Drawing.Point(384, 389);
            this.picRear1.Name = "picRear1";
            this.picRear1.Size = new System.Drawing.Size(120, 50);
            this.picRear1.TabIndex = 3;
            this.picRear1.TabStop = false;
            // 
            // picRear2
            // 
            this.picRear2.Location = new System.Drawing.Point(510, 389);
            this.picRear2.Name = "picRear2";
            this.picRear2.Size = new System.Drawing.Size(120, 50);
            this.picRear2.TabIndex = 3;
            this.picRear2.TabStop = false;
            // 
            // picSnip
            // 
            this.picSnip.Location = new System.Drawing.Point(636, 389);
            this.picSnip.Name = "picSnip";
            this.picSnip.Size = new System.Drawing.Size(120, 50);
            this.picSnip.TabIndex = 3;
            this.picSnip.TabStop = false;
            // 
            // lblMicr
            // 
            this.lblMicr.Font = new System.Drawing.Font("Document Processor Font", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicr.Location = new System.Drawing.Point(132, 442);
            this.lblMicr.Name = "lblMicr";
            this.lblMicr.Size = new System.Drawing.Size(624, 23);
            this.lblMicr.TabIndex = 4;
            // 
            // tctrl1
            // 
            this.tctrl1.Controls.Add(this.tabImages);
            this.tctrl1.Controls.Add(this.tabSettings);
            this.tctrl1.Controls.Add(this.tabLog);
            this.tctrl1.Location = new System.Drawing.Point(12, 66);
            this.tctrl1.Name = "tctrl1";
            this.tctrl1.SelectedIndex = 0;
            this.tctrl1.Size = new System.Drawing.Size(770, 498);
            this.tctrl1.TabIndex = 5;
            // 
            // tabImages
            // 
            this.tabImages.Controls.Add(this.lstImageList);
            this.tabImages.Controls.Add(this.lblMicr);
            this.tabImages.Controls.Add(this.picLarge);
            this.tabImages.Controls.Add(this.picSnip);
            this.tabImages.Controls.Add(this.picFront1);
            this.tabImages.Controls.Add(this.picRear2);
            this.tabImages.Controls.Add(this.picFront2);
            this.tabImages.Controls.Add(this.picRear1);
            this.tabImages.Location = new System.Drawing.Point(4, 22);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(762, 472);
            this.tabImages.TabIndex = 0;
            this.tabImages.Text = "Images";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(762, 472);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTrkBaseConfig);
            this.groupBox2.Controls.Add(this.txtTrkBaseWrite);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 139);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paths";
            // 
            // txtTrkBaseConfig
            // 
            this.txtTrkBaseConfig.Location = new System.Drawing.Point(85, 39);
            this.txtTrkBaseConfig.Name = "txtTrkBaseConfig";
            this.txtTrkBaseConfig.Size = new System.Drawing.Size(300, 20);
            this.txtTrkBaseConfig.TabIndex = 1;
            this.txtTrkBaseConfig.Text = ".";
            // 
            // txtTrkBaseWrite
            // 
            this.txtTrkBaseWrite.Location = new System.Drawing.Point(85, 13);
            this.txtTrkBaseWrite.Name = "txtTrkBaseWrite";
            this.txtTrkBaseWrite.Size = new System.Drawing.Size(300, 20);
            this.txtTrkBaseWrite.TabIndex = 1;
            this.txtTrkBaseWrite.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "trkBaseConfig";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "trkBaseWrite";
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(762, 472);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(756, 466);
            this.txtLog.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 576);
            this.Controls.Add(this.tctrl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "LLAPI Exerciser";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFront1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFront2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnip)).EndInit();
            this.tctrl1.ResumeLayout(false);
            this.tabImages.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnectStart;
        private System.Windows.Forms.Button btnStopDisconnect;
        private System.Windows.Forms.PictureBox picLarge;
        private System.Windows.Forms.ListBox lstImageList;
        private System.Windows.Forms.PictureBox picFront1;
        private System.Windows.Forms.PictureBox picFront2;
        private System.Windows.Forms.PictureBox picRear1;
        private System.Windows.Forms.PictureBox picRear2;
        private System.Windows.Forms.PictureBox picSnip;
        private System.Windows.Forms.ProgressBar bar1;
        private System.Windows.Forms.Label lblMicr;
        private System.Windows.Forms.TabControl tctrl1;
        private System.Windows.Forms.TabPage tabImages;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTrkBaseConfig;
        private System.Windows.Forms.TextBox txtTrkBaseWrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowImages;
        private System.Windows.Forms.CheckBox chkAlternatePockets;
    }
}

