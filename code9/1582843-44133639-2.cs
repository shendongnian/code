    internal class ShakespeareDownloader
    {
        private const string sonnetsShakespeare = "http://www.gutenberg.org/cache/epub/1041/pg1041.txt";
        public string DownloadSonnets()
        {
            string bookShakespeareSonnets = null;
            using (var downloader = new WebClient())
            {
                bookShakespeareSonnets = downloader.DownloadString(sonnetsShakespeare);
            }
            return bookShakespeareSonnets;
        }
    }
