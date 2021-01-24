    public class DownloadManager
    {
        public void DownloadFile(string sourceUrl, string targetFolder)
        {
            WebClient downloader = new WebClient();
                // fake as if you are a browser making the request.
            downloader.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
            downloader.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
  
            downloader.DownloadFileAsync(new Uri(sourceUrl), targetFolder);
              
        }
        private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
                // display completion status.
            if (e.Error != null)
                Console.WriteLine(e.Error.Message);
            else
                Console.WriteLine("Download Completed!!!");
        }
    }
