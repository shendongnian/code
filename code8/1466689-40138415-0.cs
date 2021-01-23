    [assembly: Dependency ( typeof (--yournamespace--.Downloader))]
    public class Downloader : IDownloader
    {
        public byte[] Download(string Url)
        {
            //This code is synchronous, I would recommend to do it asynchronously
            WebClient wc = new WebClient();
            return wc.DownloadData(Url);
        }
    }
