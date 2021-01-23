        private async Task LoadPageAsync(string url, int timeOutInSeconds)
        {
            using (System.Threading.SemaphoreSlim semaphore = new System.Threading.SemaphoreSlim(0, 1))
            {
                bool loaded = false;
                webBrowser.LoadCompleted += (s, e) =>
                {
                    semaphore.Release();
                    loaded = true;
                };
                webBrowser.Navigate(url);
                await semaphore.WaitAsync(TimeSpan.FromSeconds(timeOutInSeconds));
                if (loaded)
                {
                    //page was loaded
                }
                else
                {
                    //page was not loaded...
                }
            }
        }
