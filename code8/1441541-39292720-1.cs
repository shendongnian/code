    private WebClient webClient = null;
    private void btnDownload_Click(object sender, EventArgs e) {
      // Is file downloading yet?
      if (webClient != null)
        return;
      webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed); 
      webClient.DownloadFileAsync(new Uri("http://---/file.zip"), @"c:\file.zip");
    }     
    private void Completed(object sender, AsyncCompletedEventArgs e) {
      webClient = null;
      MessageBox.Show("Download completed!");
    }
