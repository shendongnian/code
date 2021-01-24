      public class DownloadHandler : IDownloadHandler
        {
            public event EventHandler<DownloadItem> OnBeforeDownloadFired;
    
            public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
    
            public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
            {
                var handler = OnBeforeDownloadFired;
                if (handler != null)
                {
                    handler(this, downloadItem);
                }
    
                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                    }
                }
            }
    
            public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
            {
                var handler = OnDownloadUpdatedFired;
                if (handler != null)
                {
                    handler(this, downloadItem);
                }
            }
        }
