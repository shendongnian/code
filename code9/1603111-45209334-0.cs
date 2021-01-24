    public class UrlChecker
    {
        private readonly int _threadsCount;
        private readonly ConcurrentQueue<string> _urlsQueue;
        public UrlChecker(int threadsCount = 1)
        {
            _threadsCount = threadsCount;
            _urlsQueue = new ConcurrentQueue<string>();
        }
        public void Start()
        {
            var threadList = new List<Thread>();
            for (int i = 0; i < _threadsCount; i++)
            {
                threadList.Add(new Thread(ProcessUrls) { IsBackground = true });
            }
            threadList.ForEach(r => r.Start());
            threadList.ForEach(r => r.Join());
        }
        public void ProcessUrls()
        {
            try
            {
                while (_urlsQueue.IsEmpty == false)
                {
                    string url;
                    if (_urlsQueue.TryDequeue(out url) && url != null)
                    {
                        try
                        {
                            // process your url
                        }
                        catch (Exception ex)
                        {
                            // TODO: log url processing error
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: log thread error
            }
        }
    }
