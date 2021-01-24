    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
    
    public class HttpClientFactory : IHttpClientFactory
    {
        static string baseAddress = "http://example.com";
    
        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            return client;
        }
    
        protected virtual void SetupClientDefaults(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(30); //set your own timeout.
            client.BaseAddress = new Uri(baseAddress);
        }
    }
