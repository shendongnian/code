    public class UrlScraper
    {
        private readonly ConcurrentQueue<UrlToScrape> _queue = new ConcurrentQueue<UrlToScrape>();
        private int _inProcessUrlCounter;
        private readonly List<string> _processedUrls = new List<string>();
        public UrlScraper(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                _queue.Enqueue(new UrlToScrape {Url = url, Depth = 1});
            }
        }
        public void ScrapeUrls()
        {
            while (_queue.TryDequeue(out var dequeuedUrl) || _inProcessUrlCounter > 0)
            {
                if (dequeuedUrl != null)
                {
                    // Make sure you don't go more levels deep than you want to.
                    if (dequeuedUrl.Depth > 5) continue;
                    if (_processedUrls.Contains(dequeuedUrl.Url)) continue;
                    _processedUrls.Add(dequeuedUrl.Url);
                    Interlocked.Increment(ref _inProcessUrlCounter);
                    var url = dequeuedUrl;
                    Task.Run(() => ProcessUrl(url));
                }
            }
        }
        private void ProcessUrl(UrlToScrape url)
        {
            try
            {
                // As the process discovers more urls to scrape,
                // pretend that this is one of those new urls.
                var someNewUrl = "http://discovered";
                _queue.Enqueue(new UrlToScrape { Url = someNewUrl, Depth = url.Depth + 1 });
            }
            catch (Exception ex)
            {
                // whatever you want to do with this
            }
            finally
            {
                Interlocked.Decrement(ref _inProcessUrlCounter);
            }
        }
    }
