    public interface IDownloader
    {
        void DownloadFile(string url, string folder);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }
    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public string FilePath = string.Empty;
        public DownloadEventArgs(bool fileSaved, string filePath)
        {
            FileSaved = fileSaved;
            FilePath = filePath;
        }
    }
