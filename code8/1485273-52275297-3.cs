    public class MyCustomHttpClientFactory : DefaultHttpClientFactory, IMyCustomHttpClientFactory
    {
        private readonly HttpClient _httpClient;
        public MyCustomHttpClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            return _httpClient;
        }
    }
