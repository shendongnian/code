    public void DownloadFile(string sourceUrl, string targetFolder)
    {
        WebClient downloader = new WebClient();
        downloader.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
    downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
    downloader.DownloadProgressChanged +=
        new DownloadProgressChangedEventHandler(Downloader_DownloadProgressChanged);    
    downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
        downloader.DownloadProgressChanged +=
            new DownloadProgressChangedEventHandler(Downloader_DownloadProgressChanged);
        downloader.DownloadFileAsync(new Uri(sourceUrl.Replace(@"\","")), targetFolder);
        while (downloader.IsBusy) { }
    }
    private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        //Console.Write(e.BytesReceived + " " + e.ProgressPercentage);  
        Console.Write("%" + e.ProgressPercentage);
    }
