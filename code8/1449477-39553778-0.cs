    private TaskCompletionSource<bool> _tcs;
    private async void DownloadForm_Shown(object sender, EventArgs e) {
       WebClient client = new WebClient();
       client.DownloadProgressChanged += client_DownloadProgressChanged;
       client.DownloadFileCompleted += client_DownloadFileCompleted;
       await startDownload(client);
    }
    
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
        progressBar.Value = e.ProgressPercentage;
        labelProgress.Text = String.Format("Downloaded {0} of {1} bytes", e.BytesReceived, e.TotalBytesToReceive);
    }
    void client_DownloadFileCompleted(object sender, DownloadFileCompletedEventArgs e) {
        // whatever else you have in this event handler, and then...
        _tcs.SetResult(true);
    }
    
    private async Task startDownload(WebClient client) {
       //files contains all URL links
       foreach (string str in files) {
          string urlDownload = HttpUtility.UrlPathEncode(str);
          //location is variable where file will be stored
          _tcs = new TaskCompletionSource<bool>();
          client.DownloadFileAsync(new Uri(urlDownload), location);
          await _tcs.Task;
       }
       _tcs = null; 
    }
