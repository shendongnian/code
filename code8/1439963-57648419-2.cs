    [assembly: Dependency(typeof(Downloader_iOS))]
    namespace Antsig.iOS.Services
    {
        public class Downloader_iOS : IDownloader
        {
            public event EventHandler<DownloadEventArgs> OnFileDownloaded;
            string pathToNewFolder = string.Empty;
            public void DownloadFile(string url, string folder)
            {
                pathToNewFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), folder);
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    string pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                    webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
                }
                catch (Exception)
                {
                    if (OnFileDownloaded != null){  OnFileDownloaded.Invoke(this, new DownloadEventArgs(false,"")); }
                }
            }
            private void Completed(object sender, AsyncCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    if (OnFileDownloaded != null){ OnFileDownloaded.Invoke(this, new DownloadEventArgs(false,"")); }
                }
                else
                {
                    if (OnFileDownloaded != null){ OnFileDownloaded.Invoke(this, new DownloadEventArgs(true, pathToNewFolder)); }
                }
            }
        }
    }
