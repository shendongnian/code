     private void button1_Click(object sender, EventArgs e)
        {
            
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            lastDownloaded = DateTime.Now;
            t.Interval = 1000;
            t.Tick += T_Tick;
            wc.DownloadFileAsync(new Uri("https://github.com/google/google-api-dotnet-client/archive/master.zip"), @"C:\Users\chkri\AppData\Local\Temp\master.zip");
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastDownloaded).TotalMilliseconds > 1000)
            {
                wc.CancelAsync();
            }
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
            lastDownloaded = DateTime.Now;
            lblProgress.Text = e.BytesReceived + "/" + e.TotalBytesToReceive;
        }
