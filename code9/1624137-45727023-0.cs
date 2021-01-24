    public class HttpService : IHttpService
    {
        private static readonly int MAX_CLIENT = 5;
        private Dictionary<HttpConfig, HttpClient> mClients;
        private Queue<HttpConfig> mClientSequence;
        public HttpService()
        {
            mClients = new Dictionary<HttpConfig, HttpClient>();
            mClientSequence = new Queue<HttpConfig>();
        }
        private HttpClient CreateHttpClientAsync(HttpConfig config)
        {
            HttpClient httpClient;
            if (mClients.ContainsKey(config))
            {
                httpClient = mClients[config];
            }
            else
            {
                // TODO: Create HttpClient...
                if (mClientSequence.Count >= MAX_CLIENT)
                {
                    // Remove the first item
                    var removingConfig = mClientSequence.Dequeue();
                    mClients.Remove(removingConfig);
                }
                mClients[config] = httpClient;
                mClientSequence.Enqueue(config);
            }
            return httpClient;
        }
    ...
    }
