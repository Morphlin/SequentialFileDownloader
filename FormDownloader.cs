using System;
using System.Net;
using System.Linq;
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
        /// URL list.
        /// </summary>
        private Queue<KeyValuePair<string, string>> _downloadUrls;

        /// <summary>
        /// Cancel var to keep track of the cancel request.
        /// </summary>
        private bool Cancel;

        /// <summary>
        /// Count of the current downloads sequence.
        /// </summary>
        private int DownloadCount = 0;

        /// <summary>
        /// Start button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (TextBoxStartIndex.Text.Length > 0)
            {
                Timer.Start();
                ButtonStop.Text = "St&op";
                ButtonStart.Enabled = false;
                ButtonStop.Enabled = true;
                ButtonBrowse.Enabled = false;
                ComboBoxUrl.Enabled = false;
                ComboBoxDirectory.Enabled = false;
                TextBoxFilename.Enabled = false;
                TextBoxStartIndex.Enabled = false;
                TextBoxEndIndex.Enabled = false;
                LabelProgress.Text = "0 / 0";
                ProgressBarSequence.Value = 0;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.NoProgress);
                LabelStatus.Text = "Downloading...";

                int i;
                _downloadUrls = new Queue<KeyValuePair<string, string>>();
                for (i = Convert.ToInt32(TextBoxStartIndex.Text); i <= Convert.ToInt32(TextBoxEndIndex.Text); i++)
                {
                    _downloadUrls.Enqueue(new KeyValuePair<string, string>(String.Format(ComboBoxUrl.Text, i.ToString().PadLeft(3, '0')), String.Format(ComboBoxDirectory.Text + TextBoxFilename.Text, i.ToString().PadLeft(3, '0'))));
                }

                // Starts the download
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
        private void DownloadFile()
        {
            if (_downloadUrls.Any() && Cancel == false)
            {
                DownloadCount++;
                var url = _downloadUrls.Dequeue();
                client.DownloadFileAsync(new Uri(url.Key), url.Value);
                LabelDownloadingUrl.Text = url.Key;
                return;
            }

            // End of the download
            Timer.Stop();
            if (Cancel)
            {
                LabelStatus.Text = "Sequence cancelled at " + DownloadCount + ". " + Timer.Elapsed;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Error);
                Cancel = false;
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
            Timer.Reset();
            DownloadCount = 0;
        }

        /// <summary>
        /// Download complete event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // handle error scenario
                MessageBox.Show("Download error: " + e.Error.Message);
                LabelStatus.Text = "Download error at " + DownloadCount + ". " + Timer.Elapsed;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Error);
                return;
            }
            if (e.Cancelled)
            {
                // handle cancelled scenario
                MessageBox.Show("Download cancelled by network!");
                LabelStatus.Text = "Download cancelled by network at " + DownloadCount + ". " + Timer.Elapsed;
                TaskbarProgress.SetState(Handle, TaskbarProgress.TaskbarStates.Error);
                return;
            }
            LabelProgress.Text = DownloadCount + " / " +(Convert.ToInt32(TextBoxEndIndex.Text) - Convert.ToInt32(TextBoxStartIndex.Text));
            var Progress = Convert.ToInt32((DownloadCount/(Convert.ToDecimal(TextBoxEndIndex.Text) - (Convert.ToDecimal(TextBoxStartIndex.Text)-1)))*100);
            ProgressBarSequence.Value = Progress;
            TaskbarProgress.SetValue(Handle, Progress, 100);
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
                ComboBoxDirectory.Text = FolderBrowserDialogDownloadLocation.SelectedPath + "\\";
            }
        }
    }
}
