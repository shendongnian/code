    public async Task<string[]> DownloadStringsAsync(string[] urls)
        {
            var tasks = new Task<string>[urls.Length];
            for(int i=0; i<tasks.Length; i++)
            {
                tasks[i] = DownloadStringAsync(urls[i]);
            }
            return await Task.WhenAll(tasks);
        }
        public async Task<string> DownloadStringAsync(string url)
        {
            //validate!
            using(var client = new WebClient())
            {
                //optionally process and return
                return await client.DownloadStringTaskAsync(url)
                    .ConfigureAwait(false);
            }
        }
