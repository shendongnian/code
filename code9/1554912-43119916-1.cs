    public class MyRestClient : IRestClient
    {
        private readonly HttpClient client;
        public MyRestClient(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor.HttpClient;
        }
    }
