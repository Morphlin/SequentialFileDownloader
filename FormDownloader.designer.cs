namespace SequentialFileDownloader
{
    partial class FormDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownloader));
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ProgressBarSequence = new System.Windows.Forms.ProgressBar();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.TextBoxStartIndex = new System.Windows.Forms.TextBox();
            this.TextBoxEndIndex = new System.Windows.Forms.TextBox();
            this.TextBoxFilename = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.ProgressBarDownloading = new System.Windows.Forms.ProgressBar();
            this.LabelDownloadingUrl = new System.Windows.Forms.Label();
            this.ComboBoxUrl = new System.Windows.Forms.ComboBox();
            this.ComboBoxDirectory = new System.Windows.Forms.ComboBox();
            this.FolderBrowserDialogDownloadLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.HelpProviderDownload = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HelpProviderDownload.SetHelpString(this.ButtonStart, "Start button. Fires up the sequential download.");
            this.ButtonStart.Location = new System.Drawing.Point(94, 213);
            this.ButtonStart.Name = "ButtonStart";
            this.HelpProviderDownload.SetShowHelp(this.ButtonStart, true);
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "St&art";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ProgressBarSequence
            // 
            this.ProgressBarSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarSequence.Location = new System.Drawing.Point(33, 182);
            this.ProgressBarSequence.Name = "ProgressBarSequence";
            this.ProgressBarSequence.Size = new System.Drawing.Size(364, 24);
            this.ProgressBarSequence.TabIndex = 1;
            // 
            // ButtonStop
            // 
            this.ButtonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStop.Enabled = false;
            this.HelpProviderDownload.SetHelpString(this.ButtonStop, "Stop, interrupt and close button.");
            this.ButtonStop.Location = new System.Drawing.Point(261, 212);
            this.ButtonStop.Name = "ButtonStop";
            this.HelpProviderDownload.SetShowHelp(this.ButtonStop, true);
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 2;
            this.ButtonStop.Text = "St&op";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // TextBoxStartIndex
            // 
            this.TextBoxStartIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HelpProviderDownload.SetHelpString(this.TextBoxStartIndex, "Start index. Inclusive.");
            this.TextBoxStartIndex.Location = new System.Drawing.Point(33, 214);
            this.TextBoxStartIndex.Name = "TextBoxStartIndex";
            this.HelpProviderDownload.SetShowHelp(this.TextBoxStartIndex, true);
            this.TextBoxStartIndex.Size = new System.Drawing.Size(45, 20);
            this.TextBoxStartIndex.TabIndex = 5;
            this.TextBoxStartIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxEndIndex
            // 
            this.TextBoxEndIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpProviderDownload.SetHelpString(this.TextBoxEndIndex, "End index. Inclusive.");
            this.TextBoxEndIndex.Location = new System.Drawing.Point(352, 213);
            this.TextBoxEndIndex.Name = "TextBoxEndIndex";
            this.HelpProviderDownload.SetShowHelp(this.TextBoxEndIndex, true);
            this.TextBoxEndIndex.Size = new System.Drawing.Size(45, 20);
            this.TextBoxEndIndex.TabIndex = 6;
            this.TextBoxEndIndex.Text = "469";
            this.TextBoxEndIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxFilename
            // 
            this.TextBoxFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpProviderDownload.SetHelpString(this.TextBoxFilename, "Download filename. Sequence number to be replaced by {0}.");
            this.TextBoxFilename.Location = new System.Drawing.Point(246, 69);
            this.TextBoxFilename.Name = "TextBoxFilename";
            this.HelpProviderDownload.SetShowHelp(this.TextBoxFilename, true);
            this.TextBoxFilename.Size = new System.Drawing.Size(91, 20);
            this.TextBoxFilename.TabIndex = 7;
            this.TextBoxFilename.Text = "sn0{0}.mp3";
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBrowse.Location = new System.Drawing.Point(343, 68);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(54, 22);
            this.ButtonBrowse.TabIndex = 8;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // LabelProgress
            // 
            this.LabelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpProviderDownload.SetHelpString(this.LabelProgress, "Downloaded files / Total files to download.");
            this.LabelProgress.Location = new System.Drawing.Point(176, 218);
            this.LabelProgress.Name = "LabelProgress";
            this.HelpProviderDownload.SetShowHelp(this.LabelProgress, true);
            this.LabelProgress.Size = new System.Drawing.Size(79, 13);
            this.LabelProgress.TabIndex = 9;
            this.LabelProgress.Text = "0 / 0";
            this.LabelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBarDownloading
            // 
            this.ProgressBarDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarDownloading.Location = new System.Drawing.Point(33, 138);
            this.ProgressBarDownloading.Name = "ProgressBarDownloading";
            this.ProgressBarDownloading.Size = new System.Drawing.Size(364, 18);
            this.ProgressBarDownloading.TabIndex = 10;
            // 
            // LabelDownloadingUrl
            // 
            this.LabelDownloadingUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelDownloadingUrl.Location = new System.Drawing.Point(33, 107);
            this.LabelDownloadingUrl.Name = "LabelDownloadingUrl";
            this.LabelDownloadingUrl.Size = new System.Drawing.Size(364, 28);
            this.LabelDownloadingUrl.TabIndex = 11;
            this.LabelDownloadingUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxUrl
            // 
            this.ComboBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxUrl.FormattingEnabled = true;
            this.HelpProviderDownload.SetHelpString(this.ComboBoxUrl, "Download URL. Sequence number to be replaced by {0}.");
            this.ComboBoxUrl.Items.AddRange(new object[] {
            "http://twit.cachefly.net/audio/sn/sn0{0}/sn0{0}.mp3",
            "http://twit.cachefly.net/video/sn/sn0{0}/sn0{0}_h264b_864x480_500.mp4"});
            this.ComboBoxUrl.Location = new System.Drawing.Point(33, 28);
            this.ComboBoxUrl.Name = "ComboBoxUrl";
            this.HelpProviderDownload.SetShowHelp(this.ComboBoxUrl, true);
            this.ComboBoxUrl.Size = new System.Drawing.Size(364, 21);
            this.ComboBoxUrl.TabIndex = 12;
            // 
            // ComboBoxDirectory
            // 
            this.ComboBoxDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxDirectory.FormattingEnabled = true;
            this.HelpProviderDownload.SetHelpString(this.ComboBoxDirectory, "Download location. Use the browse button for easy path selection.");
            this.ComboBoxDirectory.Items.AddRange(new object[] {
            "C:\\Users\\Alex\\Downloads\\sn\\"});
            this.ComboBoxDirectory.Location = new System.Drawing.Point(33, 68);
            this.ComboBoxDirectory.Name = "ComboBoxDirectory";
            this.HelpProviderDownload.SetShowHelp(this.ComboBoxDirectory, true);
            this.ComboBoxDirectory.Size = new System.Drawing.Size(207, 21);
            this.ComboBoxDirectory.TabIndex = 13;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelStatus.Location = new System.Drawing.Point(33, 166);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(364, 13);
            this.LabelStatus.TabIndex = 14;
            this.LabelStatus.Text = "Specify URL, Directory, Filename, Start index and End index.";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 253);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.ComboBoxDirectory);
            this.Controls.Add(this.ComboBoxUrl);
            this.Controls.Add(this.LabelDownloadingUrl);
            this.Controls.Add(this.ProgressBarDownloading);
            this.Controls.Add(this.LabelProgress);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.TextBoxFilename);
            this.Controls.Add(this.TextBoxEndIndex);
            this.Controls.Add(this.TextBoxStartIndex);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ProgressBarSequence);
            this.Controls.Add(this.ButtonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.HelpProviderDownload.SetHelpString(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDownloader";
            this.HelpProviderDownload.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sequential File Downloader";
            this.Load += new System.EventHandler(this.FormAsync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.ProgressBar ProgressBarSequence;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.TextBox TextBoxStartIndex;
        private System.Windows.Forms.TextBox TextBoxEndIndex;
        private System.Windows.Forms.TextBox TextBoxFilename;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Label LabelProgress;
        private System.Windows.Forms.ProgressBar ProgressBarDownloading;
        private System.Windows.Forms.Label LabelDownloadingUrl;
        private System.Windows.Forms.ComboBox ComboBoxUrl;
        private System.Windows.Forms.ComboBox ComboBoxDirectory;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogDownloadLocation;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.HelpProvider HelpProviderDownload;
    }
}

