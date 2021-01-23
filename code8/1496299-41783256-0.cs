    public class MyDownloadHandler : IDownloadHandler {
        private ProgressBar _bar;
        public MyDownloadHandler(ProgressBar bar) {
            _bar = bar;
        }
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback) {
        }
        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback) {
            _bar.Dispatcher.Invoke(new Action(() => {
                Debug.Print("{0}/{1} bytes", downloadItem.ReceivedBytes, downloadItem.TotalBytes);
                _bar.Maximum = downloadItem.TotalBytes;
                _bar.Value = downloadItem.ReceivedBytes;
            }));
        }
    }
