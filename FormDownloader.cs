using System;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SequentialFileDownloader
{
    /// <summary>
    /// File Downloader main Form.
    /// </summary>
    public partial class FormDownloader : Form
    {
        /// <summary>
        /// Form Constuctor.
        /// </summary>
        public FormDownloader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// WebClient Instance.
        /// </summary>
        private WebClient client = new WebClient();

        /// <summary>
        /// WebClient events assignment during form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAsync_Load(object sender, EventArgs e)
        {
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
        }

        /// <summary>
        /// Download duration tracking.
        /// </summary>
        private Stopwatch Timer = new Stopwatch();

        /// <summary>
        /// Cancel var to keep track of the cancel request.
        /// </summary>
        private bool Cancel;

        /// <summary>
        /// Index of the first downloads sequence.
        /// </summary>
        private int DownloadIndexStart = 0;

        /// <summary>
        /// Index of the last downloads sequence.
        /// </summary>
        private int DownloadIndexEnd = 0;

        /// <summary>
        /// Index of the current downloads sequence.
        /// </summary>
        private int DownloadIndex = 0;

        /// <summary>
        /// End count of the current downloads sequence.
        /// </summary>
        private int DownloadCountEnd = 0;

        /// <summary>
        /// Count of the current downloads sequence.
        /// </summary>
        private int DownloadCount = 0;

        /// <summary>
        /// Activity log of the current sequence.
        /// </summary>
        private List<string> DownloadLog;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxUrl_TextChanged(object sender, EventArgs e)
        {
            TextBoxFilename.Text = ComboBoxUrl.Text.Split('/')[ComboBoxUrl.Text.Split('/').Length - 1];
        }

        /// <summary>
        /// Start button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (TextBoxStartIndex.Text.Length > 0)
            {
                ButtonStop.Text = "St&op";
                ButtonStart.Enabled = false;
                ButtonStop.Enabled = true;
                ButtonBrowse.Enabled = false;
                ComboBoxUrl.Enabled = false;
                ComboBoxDirectory.Enabled = false;
                TextBoxFilename.Enabled = false;
                TextBoxStartIndex.Enabled = false;
                TextBoxEndIndex.Enabled = false;
                ProgressBarSequence.Value = 0;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.NoProgress);
                LabelStatus.Text = "Downloading...";

                // Starts the download
                DownloadLog = new List<string>();
                DownloadLog.Add("Sequence initiated: " + DateTime.Now);
                Timer.Reset();
                Timer.Start();
                Cancel = false;
                DownloadIndexStart = Convert.ToInt32(TextBoxStartIndex.Text);
                DownloadIndexEnd = Convert.ToInt32(TextBoxEndIndex.Text);
                DownloadIndex = DownloadIndexStart;
                DownloadCount = 0;
                DownloadCountEnd = (DownloadIndexEnd - DownloadIndexStart) + 1;
                LabelProgress.Text = "0 / " + DownloadCountEnd;
                DownloadFile();
            }
            else
            {
                MessageBox.Show("Please enter start index!");
            }
        }

        /// <summary>
        /// Stop download, interrupt download and close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (!client.IsBusy)
            {
                Close();
            }
            if (Cancel)
            {
                client.CancelAsync();
                ButtonStop.Text = "Cl&ose";
                LabelStatus.Text = "Download cancelled!";
                return;
            }
            Cancel = true;
            ButtonStop.Text = "&Cancel";
            LabelStatus.Text = "Sequence stopped. Finishing last download...";
        }

        /// <summary>
        /// Download method that is called sequentially after each download is finished.
        /// </summary>
        private void DownloadFile(bool Abort = false)
        {
            if ((DownloadIndex <= DownloadIndexEnd) && Cancel == false && Abort == false)
            {
                var DownloadUri = new Uri(String.Format(ComboBoxUrl.Text, DownloadIndex.ToString().PadLeft(3, '0')));
                var DownloadPath = String.Format(ComboBoxDirectory.Text + "\\" + TextBoxFilename.Text, DownloadIndex.ToString().PadLeft(3, '0'));
                client.DownloadFileAsync(DownloadUri, DownloadPath, DownloadPath);
                LabelDownloadingUrl.Text = DownloadUri.OriginalString;
                return;
            }

            // End of the download
            Timer.Stop();
            DownloadLog.Add("Sequence terminated: " + Timer.Elapsed + " at " + DateTime.Now);
            if (Cancel || Abort)
            {
                LabelStatus.Text = "Sequence " + (Abort ? "aborted" : "cancelled") + " at " + DownloadIndex + ". " + Timer.Elapsed;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Error);
            }
            else
            {
                LabelStatus.Text = "Sequence complete! " + DownloadCount + " downloaded." + " " + Timer.Elapsed;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Paused);
            }
            ButtonStop.Text = "Cl&ose";
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = true;
            ButtonBrowse.Enabled = true;
            ComboBoxUrl.Enabled = true;
            ComboBoxDirectory.Enabled = true;
            TextBoxFilename.Enabled = true;
            TextBoxStartIndex.Enabled = true;
            TextBoxEndIndex.Enabled = true;
        }

        /// <summary>
        /// Download complete event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // handle error scenario
            if (e.Error != null)
            {
                var DownloadErrorMessage = "Download error at " + DownloadIndex + ". " + Timer.Elapsed + "\n\r";
                DownloadLog.Add(DownloadErrorMessage + "Message:" + e.Error.Message);

                //deletes partially downloaded file
                var PartialDownload = new FileInfo((string)e.UserState);
                if (PartialDownload.Exists)
                {
                    PartialDownload.Delete();
                }
                else
                {
                    DownloadLog.Add("Error attempting to delete partially downloaded file: " + PartialDownload.FullName);
                }
                
                // handle cancel scenario
                if (!e.Cancelled)
                {
                    // error display and question
                    LabelStatus.Text = "Download error at " + DownloadIndex + ". " + Timer.Elapsed;
                    TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Error);
                    var MsgRes = MessageBox.Show(DownloadErrorMessage, "Sequential File Downloader", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    switch (MsgRes)
                    {
                        case DialogResult.Abort:
                            DownloadLog.Add(DownloadErrorMessage + "Command: User abort.");
                            DownloadFile(true);
                            return;
                        case DialogResult.Retry:
                            DownloadLog.Add(DownloadErrorMessage + "Command: User retry.");
                            DownloadFile();
                            return;
                    }
                    DownloadLog.Add(DownloadErrorMessage + "Command: User ignore.");
                }
                else
                {
                    DownloadFile();
                    return;
                }
            }
            if (e.Error == null) DownloadCount++;
            DownloadIndex++;
            LabelProgress.Text = DownloadCount + " / " + DownloadCountEnd;
            var ProgressPercentage = Convert.ToInt32((DownloadCount / Convert.ToDecimal(DownloadCountEnd)) * 100);
            ProgressBarSequence.Value = ProgressPercentage;
            TaskbarProgress.SetValue(Handle, ProgressPercentage, 100);
            TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Normal);
            DownloadFile();
        }

        /// <summary>
        /// Download progress event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            ProgressBarDownloading.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        /// <summary>
        /// Browse button for download location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var folder = FolderBrowserDialogDownloadLocation.ShowDialog();
            if (folder == DialogResult.OK)
            {
                ComboBoxDirectory.Text = FolderBrowserDialogDownloadLocation.SelectedPath;
            }
        }
    }
}
