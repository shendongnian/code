    private void button1_Click(object sender, EventArgs e)
            {
                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                lastDownloaded = DateTime.Now;
                wc.DownloadFileAsync(new Uri("https://github.com/google/google-api-dotnet-client/archive/master.zip"), @"C:\Users\chkri\AppData\Local\Temp\master.zip");
            }
    
            private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    lblProgress.Text = e.Error.Message;
                }
            }
    
            private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                lblProgress.Text = e.BytesReceived + "/" + e.TotalBytesToReceive;
            }
