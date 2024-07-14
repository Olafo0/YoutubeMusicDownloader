namespace YoutubeMusicDownloader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            label4 = new Label();
            currentSongTB = new TextBox();
            qualityLB = new Label();
            qualityCB = new ComboBox();
            searchVideo = new Button();
            label3 = new Label();
            label2 = new Label();
            formatCB = new ComboBox();
            downloadBTN = new Button();
            youtubeUrlTB = new TextBox();
            progressbarLB = new Label();
            progressBar = new ProgressBar();
            panel2 = new Panel();
            openFileBTN = new Button();
            infoBTN = new Button();
            label1 = new Label();
            downloadDirTB = new TextBox();
            resetDirBTN = new Button();
            changeDownloadDirBTN = new Button();
            downloadPanel = new Panel();
            currentProcessLB = new Label();
            okBTN = new Button();
            cancelBTN = new Button();
            FetchingPanel = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            infoPanel = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            downloadPanel.SuspendLayout();
            FetchingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(currentSongTB);
            panel1.Controls.Add(qualityLB);
            panel1.Controls.Add(qualityCB);
            panel1.Controls.Add(searchVideo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(formatCB);
            panel1.Controls.Add(downloadBTN);
            panel1.Controls.Add(youtubeUrlTB);
            panel1.Location = new Point(12, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 343);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 139);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 13;
            label4.Text = "Title";
            // 
            // currentSongTB
            // 
            currentSongTB.Location = new Point(47, 158);
            currentSongTB.Name = "currentSongTB";
            currentSongTB.ReadOnly = true;
            currentSongTB.Size = new Size(458, 23);
            currentSongTB.TabIndex = 12;
            currentSongTB.TextAlign = HorizontalAlignment.Center;
            // 
            // qualityLB
            // 
            qualityLB.AutoSize = true;
            qualityLB.Location = new Point(189, 202);
            qualityLB.Name = "qualityLB";
            qualityLB.Size = new Size(163, 15);
            qualityLB.TabIndex = 10;
            qualityLB.Text = "Select the quality of the video";
            qualityLB.Visible = false;
            // 
            // qualityCB
            // 
            qualityCB.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityCB.FormattingEnabled = true;
            qualityCB.Location = new Point(200, 220);
            qualityCB.Name = "qualityCB";
            qualityCB.Size = new Size(137, 23);
            qualityCB.TabIndex = 9;
            qualityCB.Visible = false;
            // 
            // searchVideo
            // 
            searchVideo.BackColor = SystemColors.Control;
            searchVideo.Cursor = Cursors.Hand;
            searchVideo.FlatStyle = FlatStyle.Flat;
            searchVideo.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchVideo.Location = new Point(298, 85);
            searchVideo.Name = "searchVideo";
            searchVideo.Size = new Size(139, 36);
            searchVideo.TabIndex = 8;
            searchVideo.Text = "Search";
            searchVideo.UseVisualStyleBackColor = false;
            searchVideo.Click += searchVideo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(186, 13);
            label3.Name = "label3";
            label3.Size = new Size(188, 32);
            label3.TabIndex = 7;
            label3.Text = "paste in the URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 82);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 6;
            label2.Text = "Please choose the format";
            // 
            // formatCB
            // 
            formatCB.Cursor = Cursors.Hand;
            formatCB.DropDownStyle = ComboBoxStyle.DropDownList;
            formatCB.FormattingEnabled = true;
            formatCB.Items.AddRange(new object[] { "MP4", "MP3" });
            formatCB.Location = new Point(120, 98);
            formatCB.Name = "formatCB";
            formatCB.Size = new Size(137, 23);
            formatCB.TabIndex = 5;
            formatCB.SelectedIndexChanged += formatCB_SelectedIndexChanged;
            // 
            // downloadBTN
            // 
            downloadBTN.BackColor = SystemColors.Control;
            downloadBTN.Cursor = Cursors.Hand;
            downloadBTN.Enabled = false;
            downloadBTN.FlatStyle = FlatStyle.Flat;
            downloadBTN.Location = new Point(173, 268);
            downloadBTN.Name = "downloadBTN";
            downloadBTN.Size = new Size(201, 59);
            downloadBTN.TabIndex = 4;
            downloadBTN.Text = "Download";
            downloadBTN.UseVisualStyleBackColor = false;
            downloadBTN.Click += downloadBTN_Click;
            // 
            // youtubeUrlTB
            // 
            youtubeUrlTB.Cursor = Cursors.IBeam;
            youtubeUrlTB.Location = new Point(13, 48);
            youtubeUrlTB.Name = "youtubeUrlTB";
            youtubeUrlTB.Size = new Size(522, 23);
            youtubeUrlTB.TabIndex = 0;
            // 
            // progressbarLB
            // 
            progressbarLB.AutoSize = true;
            progressbarLB.BackColor = Color.Transparent;
            progressbarLB.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            progressbarLB.Location = new Point(71, 75);
            progressbarLB.Name = "progressbarLB";
            progressbarLB.Size = new Size(41, 30);
            progressbarLB.TabIndex = 9;
            progressbarLB.Text = "0%";
            progressbarLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(59, 48);
            progressBar.Maximum = 99;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(432, 24);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(openFileBTN);
            panel2.Controls.Add(infoBTN);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(downloadDirTB);
            panel2.Controls.Add(resetDirBTN);
            panel2.Controls.Add(changeDownloadDirBTN);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(547, 101);
            panel2.TabIndex = 1;
            // 
            // openFileBTN
            // 
            openFileBTN.BackColor = SystemColors.MenuHighlight;
            openFileBTN.Cursor = Cursors.Hand;
            openFileBTN.FlatStyle = FlatStyle.Flat;
            openFileBTN.Location = new Point(420, 38);
            openFileBTN.Name = "openFileBTN";
            openFileBTN.Size = new Size(115, 30);
            openFileBTN.TabIndex = 5;
            openFileBTN.Text = "Open file";
            openFileBTN.UseVisualStyleBackColor = false;
            openFileBTN.Click += openFileBTN_Click;
            // 
            // infoBTN
            // 
            infoBTN.BackColor = SystemColors.Info;
            infoBTN.Cursor = Cursors.Hand;
            infoBTN.FlatStyle = FlatStyle.Flat;
            infoBTN.Location = new Point(3, 3);
            infoBTN.Name = "infoBTN";
            infoBTN.Size = new Size(82, 26);
            infoBTN.TabIndex = 4;
            infoBTN.Text = "INFO";
            infoBTN.UseVisualStyleBackColor = false;
            infoBTN.Click += infoBTN_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 38);
            label1.Name = "label1";
            label1.Size = new Size(172, 15);
            label1.TabIndex = 3;
            label1.Text = "This is your download directory";
            // 
            // downloadDirTB
            // 
            downloadDirTB.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            downloadDirTB.Location = new Point(13, 59);
            downloadDirTB.Name = "downloadDirTB";
            downloadDirTB.ReadOnly = true;
            downloadDirTB.Size = new Size(400, 21);
            downloadDirTB.TabIndex = 2;
            // 
            // resetDirBTN
            // 
            resetDirBTN.BackColor = Color.LightCoral;
            resetDirBTN.Cursor = Cursors.Hand;
            resetDirBTN.FlatStyle = FlatStyle.Flat;
            resetDirBTN.Location = new Point(433, 73);
            resetDirBTN.Name = "resetDirBTN";
            resetDirBTN.Size = new Size(82, 25);
            resetDirBTN.TabIndex = 1;
            resetDirBTN.Text = "Reset";
            resetDirBTN.UseVisualStyleBackColor = false;
            resetDirBTN.Click += resetDirBTN_Click;
            // 
            // changeDownloadDirBTN
            // 
            changeDownloadDirBTN.BackColor = SystemColors.Control;
            changeDownloadDirBTN.Cursor = Cursors.Hand;
            changeDownloadDirBTN.FlatStyle = FlatStyle.Flat;
            changeDownloadDirBTN.Location = new Point(420, 3);
            changeDownloadDirBTN.Name = "changeDownloadDirBTN";
            changeDownloadDirBTN.Size = new Size(115, 30);
            changeDownloadDirBTN.TabIndex = 0;
            changeDownloadDirBTN.Text = "Change Directory";
            changeDownloadDirBTN.UseVisualStyleBackColor = false;
            changeDownloadDirBTN.Click += changeDownloadDirBTN_Click;
            // 
            // downloadPanel
            // 
            downloadPanel.BackColor = SystemColors.ButtonShadow;
            downloadPanel.Controls.Add(currentProcessLB);
            downloadPanel.Controls.Add(okBTN);
            downloadPanel.Controls.Add(cancelBTN);
            downloadPanel.Controls.Add(progressbarLB);
            downloadPanel.Controls.Add(progressBar);
            downloadPanel.Location = new Point(11, 118);
            downloadPanel.Name = "downloadPanel";
            downloadPanel.Size = new Size(547, 343);
            downloadPanel.TabIndex = 2;
            downloadPanel.Visible = false;
            // 
            // currentProcessLB
            // 
            currentProcessLB.AutoSize = true;
            currentProcessLB.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentProcessLB.Location = new Point(253, 134);
            currentProcessLB.Name = "currentProcessLB";
            currentProcessLB.Size = new Size(44, 21);
            currentProcessLB.TabIndex = 12;
            currentProcessLB.Text = "xx/xx";
            currentProcessLB.TextAlign = ContentAlignment.MiddleCenter;
            currentProcessLB.Visible = false;
            // 
            // okBTN
            // 
            okBTN.BackColor = Color.PaleGreen;
            okBTN.Cursor = Cursors.Hand;
            okBTN.Enabled = false;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            okBTN.Location = new Point(104, 228);
            okBTN.Name = "okBTN";
            okBTN.Size = new Size(114, 56);
            okBTN.TabIndex = 11;
            okBTN.Text = "Ok";
            okBTN.UseVisualStyleBackColor = false;
            okBTN.Click += okBTN_Click;
            // 
            // cancelBTN
            // 
            cancelBTN.BackColor = Color.IndianRed;
            cancelBTN.Cursor = Cursors.Hand;
            cancelBTN.FlatStyle = FlatStyle.Flat;
            cancelBTN.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelBTN.Location = new Point(336, 228);
            cancelBTN.Name = "cancelBTN";
            cancelBTN.Size = new Size(114, 56);
            cancelBTN.TabIndex = 10;
            cancelBTN.Text = "Cancel";
            cancelBTN.UseVisualStyleBackColor = false;
            cancelBTN.Click += cancelBTN_Click;
            // 
            // FetchingPanel
            // 
            FetchingPanel.BackColor = SystemColors.ActiveCaption;
            FetchingPanel.Controls.Add(pictureBox1);
            FetchingPanel.Controls.Add(label5);
            FetchingPanel.Location = new Point(25, 131);
            FetchingPanel.Name = "FetchingPanel";
            FetchingPanel.Size = new Size(522, 317);
            FetchingPanel.TabIndex = 3;
            FetchingPanel.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(213, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 83);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(138, 168);
            label5.Name = "label5";
            label5.Size = new Size(237, 32);
            label5.TabIndex = 0;
            label5.Text = "Fetching information";
            // 
            // infoPanel
            // 
            infoPanel.BackColor = SystemColors.ControlDark;
            infoPanel.Controls.Add(pictureBox5);
            infoPanel.Controls.Add(pictureBox4);
            infoPanel.Controls.Add(pictureBox2);
            infoPanel.Controls.Add(pictureBox3);
            infoPanel.Location = new Point(11, 116);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(548, 345);
            infoPanel.TabIndex = 4;
            infoPanel.Visible = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(9, 251);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(218, 91);
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(237, 35);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(307, 307);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(1, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(548, 28);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(9, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(218, 210);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 473);
            Controls.Add(panel2);
            Controls.Add(downloadPanel);
            Controls.Add(FetchingPanel);
            Controls.Add(infoPanel);
            Controls.Add(panel1);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            downloadPanel.ResumeLayout(false);
            downloadPanel.PerformLayout();
            FetchingPanel.ResumeLayout(false);
            FetchingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            infoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button changeDownloadDirBTN;
        private Label label1;
        private TextBox downloadDirTB;
        private Button resetDirBTN;
        private Label label3;
        private Label label2;
        private ComboBox formatCB;
        private Button downloadBTN;
        private TextBox youtubeUrlTB;
        private ProgressBar progressBar;
        private Label progressbarLB;
        private Button infoBTN;
        private Panel downloadPanel;
        private Button cancelBTN;
        private Button okBTN;
        private Button openFileBTN;
        private Button searchVideo;
        private Label qualityLB;
        private ComboBox qualityCB;
        private Panel FetchingPanel;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label4;
        private TextBox currentSongTB;
        private Label currentProcessLB;
        private Panel infoPanel;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}