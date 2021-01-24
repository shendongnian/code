     public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }
        WebClient client;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (!string.IsNullOrEmpty(url))
            {
                Thread thread = new Thread(() =>
              {
                  Uri uri = new Uri(url);
                  string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                  client.DownloadFileAsync(uri, Application.StartupPath + "/" + filename);
              });
                thread.Start();
            }
        }
        private void Download_Load(object sender, EventArgs e)
        {
            client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar.Minimum = 0;
                double recieve = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = recieve / total * 100;
                lblStatus.Text = $"Download {string.Format("{0:0.##}", percentage)}%";
                progressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }
    }
