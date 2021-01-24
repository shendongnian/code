    Class MyMainClass
    {
        private void StartDownload()
        {
            var downloaderThread1 = new Downloader();
            var downloaderThread2 = new Downloader();
            var task1 = downloaderThread1.DownloadFileAsync(remoteAddress, downloadPath);
            var task2 = downloaderThread2.DownloadFileAsync(remoteAddress, downloadPath);
            Task.WaitAll();
        }
    
        class Downloader
        {           
            public async Task DownloadFileAsync(string remoteAddress, string downloadPath)
            {
                var client = new WebClient();
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                await client.DownloadFileTaskAsync(remoteAddress, downloadPath);
            }
        }
    }
