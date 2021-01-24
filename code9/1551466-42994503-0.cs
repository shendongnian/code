    private void DownloadChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        labelProgress.Text = string.Format("{0} Percents Completed",
                     e.BytesReceived / e.TotalBytesToReceive * 100);
    }
    private void StartDownload(object sender, EventArgs e) // Button Event
    {
        var webClient = new WebClient();
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadChanged);
        webClient.DownloadFileAsync(/* URL */);
    }
