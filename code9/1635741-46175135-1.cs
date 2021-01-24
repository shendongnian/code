    public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
    {
    
        if (downloadItem.IsComplete || downloadItem.IsCancelled)
            {
             //do stuff
            }
    }
