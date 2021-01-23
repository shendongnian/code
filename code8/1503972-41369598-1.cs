    public event EventHandler TaskCompleted;
    
        public async void DownloadAsync()
        {
            String[] urls = { "http://media.salon.com/2014/10/shutterstock_154257524-1280x960.jpg",
                                "http://www.samsung.com/us/2012-smart-blu-ray-player/img/tv-front.png" };
            var tasks = urls.Select((url, index) =>
            {
                var fileName = String.Format(@"c:\temp\image-{0}.jpg", index);
                var client = new WebClient();
                return client.DownloadFileTaskAsync(url, fileName);
            });
            await Task.WhenAll(tasks).ContinueWith(x =>
            {
                if (TaskCompleted != null)
                {
                    TaskCompleted(this, EventArgs.Empty);
                }
            });
        }
