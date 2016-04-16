namespace PlayingVideoCullan
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portNum = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.setupBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.teardownBtn = new System.Windows.Forms.Button();
            this.clientBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.packetReportCheck = new System.Windows.Forms.CheckBox();
            this.printHeaderCheck = new System.Windows.Forms.CheckBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.setupHoverBtn = new System.Windows.Forms.PictureBox();
            this.pauseHoverBtn = new System.Windows.Forms.PictureBox();
            this.playHoverBtn = new System.Windows.Forms.PictureBox();
            this.teardownHoverBtn = new System.Windows.Forms.PictureBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.videoName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.setupHoverBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseHoverBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playHoverBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teardownHoverBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect To Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Video name:";
            // 
            // portNum
            // 
            this.portNum.Location = new System.Drawing.Point(106, 6);
            this.portNum.Name = "portNum";
            this.portNum.Size = new System.Drawing.Size(49, 20);
            this.portNum.TabIndex = 4;
            this.portNum.Text = "3000";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(252, 6);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(56, 20);
            this.serverIP.TabIndex = 5;
            this.serverIP.Text = "127.0.0.1";
            // 
            // setupBtn
            // 
            this.setupBtn.Enabled = false;
            this.setupBtn.Location = new System.Drawing.Point(15, 268);
            this.setupBtn.Name = "setupBtn";
            this.setupBtn.Size = new System.Drawing.Size(85, 75);
            this.setupBtn.TabIndex = 7;
            this.setupBtn.Text = "Setup";
            this.setupBtn.UseVisualStyleBackColor = true;
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Location = new System.Drawing.Point(142, 268);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(85, 75);
            this.playBtn.TabIndex = 8;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Enabled = false;
            this.pauseBtn.Location = new System.Drawing.Point(273, 268);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(85, 75);
            this.pauseBtn.TabIndex = 9;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // teardownBtn
            // 
            this.teardownBtn.Enabled = false;
            this.teardownBtn.Location = new System.Drawing.Point(395, 268);
            this.teardownBtn.Name = "teardownBtn";
            this.teardownBtn.Size = new System.Drawing.Size(85, 75);
            this.teardownBtn.TabIndex = 10;
            this.teardownBtn.Text = "Teardown";
            this.teardownBtn.UseVisualStyleBackColor = true;
            // 
            // clientBox
            // 
            this.clientBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clientBox.Location = new System.Drawing.Point(15, 349);
            this.clientBox.Multiline = true;
            this.clientBox.Name = "clientBox";
            this.clientBox.ReadOnly = true;
            this.clientBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientBox.Size = new System.Drawing.Size(353, 129);
            this.clientBox.TabIndex = 11;
            // 
            // serverBox
            // 
            this.serverBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serverBox.Location = new System.Drawing.Point(15, 486);
            this.serverBox.Multiline = true;
            this.serverBox.Name = "serverBox";
            this.serverBox.ReadOnly = true;
            this.serverBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverBox.Size = new System.Drawing.Size(353, 129);
            this.serverBox.TabIndex = 12;
            // 
            // packetReportCheck
            // 
            this.packetReportCheck.AutoSize = true;
            this.packetReportCheck.Location = new System.Drawing.Point(385, 371);
            this.packetReportCheck.Name = "packetReportCheck";
            this.packetReportCheck.Size = new System.Drawing.Size(95, 17);
            this.packetReportCheck.TabIndex = 13;
            this.packetReportCheck.Text = "Packet Report";
            this.packetReportCheck.UseVisualStyleBackColor = true;
            // 
            // printHeaderCheck
            // 
            this.printHeaderCheck.AutoSize = true;
            this.printHeaderCheck.Location = new System.Drawing.Point(385, 413);
            this.printHeaderCheck.Name = "printHeaderCheck";
            this.printHeaderCheck.Size = new System.Drawing.Size(85, 17);
            this.printHeaderCheck.TabIndex = 14;
            this.printHeaderCheck.Text = "Print Header";
            this.printHeaderCheck.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(395, 563);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 15;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(395, 592);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 16;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // setupHoverBtn
            // 
            this.setupHoverBtn.BackColor = System.Drawing.Color.Transparent;
            this.setupHoverBtn.Enabled = false;
            this.setupHoverBtn.Image = ((System.Drawing.Image)(resources.GetObject("setupHoverBtn.Image")));
            this.setupHoverBtn.Location = new System.Drawing.Point(141, 161);
            this.setupHoverBtn.Name = "setupHoverBtn";
            this.setupHoverBtn.Size = new System.Drawing.Size(44, 41);
            this.setupHoverBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.setupHoverBtn.TabIndex = 21;
            this.setupHoverBtn.TabStop = false;
            this.setupHoverBtn.Visible = false;
            // 
            // pauseHoverBtn
            // 
            this.pauseHoverBtn.BackColor = System.Drawing.Color.Transparent;
            this.pauseHoverBtn.Enabled = false;
            this.pauseHoverBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseHoverBtn.Image")));
            this.pauseHoverBtn.Location = new System.Drawing.Point(242, 161);
            this.pauseHoverBtn.Name = "pauseHoverBtn";
            this.pauseHoverBtn.Size = new System.Drawing.Size(44, 41);
            this.pauseHoverBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pauseHoverBtn.TabIndex = 22;
            this.pauseHoverBtn.TabStop = false;
            this.pauseHoverBtn.Visible = false;
            // 
            // playHoverBtn
            // 
            this.playHoverBtn.BackColor = System.Drawing.Color.Transparent;
            this.playHoverBtn.Enabled = false;
            this.playHoverBtn.Image = ((System.Drawing.Image)(resources.GetObject("playHoverBtn.Image")));
            this.playHoverBtn.Location = new System.Drawing.Point(192, 161);
            this.playHoverBtn.Name = "playHoverBtn";
            this.playHoverBtn.Size = new System.Drawing.Size(44, 41);
            this.playHoverBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playHoverBtn.TabIndex = 23;
            this.playHoverBtn.TabStop = false;
            this.playHoverBtn.Visible = false;
            // 
            // teardownHoverBtn
            // 
            this.teardownHoverBtn.BackColor = System.Drawing.Color.Transparent;
            this.teardownHoverBtn.Enabled = false;
            this.teardownHoverBtn.Image = ((System.Drawing.Image)(resources.GetObject("teardownHoverBtn.Image")));
            this.teardownHoverBtn.Location = new System.Drawing.Point(292, 161);
            this.teardownHoverBtn.Name = "teardownHoverBtn";
            this.teardownHoverBtn.Size = new System.Drawing.Size(44, 41);
            this.teardownHoverBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.teardownHoverBtn.TabIndex = 24;
            this.teardownHoverBtn.TabStop = false;
            this.teardownHoverBtn.Visible = false;
            // 
            // imageBox
            // 
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(15, 33);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(465, 216);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 25;
            this.imageBox.TabStop = false;
            this.imageBox.MouseEnter += new System.EventHandler(this.imageBox_MouseEnter);
            // 
            // videoName
            // 
            this.videoName.FormattingEnabled = true;
            this.videoName.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.videoName.Location = new System.Drawing.Point(381, 6);
            this.videoName.Name = "videoName";
            this.videoName.Size = new System.Drawing.Size(99, 21);
            this.videoName.TabIndex = 26;
            this.videoName.Text = "video1.mjpeg";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 627);
            this.Controls.Add(this.videoName);
            this.Controls.Add(this.teardownHoverBtn);
            this.Controls.Add(this.playHoverBtn);
            this.Controls.Add(this.pauseHoverBtn);
            this.Controls.Add(this.setupHoverBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.printHeaderCheck);
            this.Controls.Add(this.packetReportCheck);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.teardownBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.setupBtn);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.portNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox);
            this.Name = "View";
            this.Text = "Form1";
            this.MouseEnter += new System.EventHandler(this.View_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.setupHoverBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseHoverBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playHoverBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teardownHoverBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portNum;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.Button setupBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button teardownBtn;
        private System.Windows.Forms.TextBox clientBox;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.CheckBox packetReportCheck;
        private System.Windows.Forms.CheckBox printHeaderCheck;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button exitBtn;
        public System.Windows.Forms.PictureBox setupHoverBtn;
        public System.Windows.Forms.PictureBox pauseHoverBtn;
        public System.Windows.Forms.PictureBox playHoverBtn;
        public System.Windows.Forms.PictureBox teardownHoverBtn;
        public System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ComboBox videoName;
    }
}

