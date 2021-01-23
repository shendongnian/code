    public event EventHandler downloadCompleted;
        public async void DownloadNow()
        {
            if(remoteURL != null)
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                    await webClient.DownloadFileTaskAsync(remoteURL, localFile);
                }
            }
        }
    
    private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(downloadCompleted != null)
            {
                downloadCompleted(this, EventArgs.Empty);
            }
        }
