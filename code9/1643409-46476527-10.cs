    class HttpClientFactory : IHttpClientFactory
    {
        private readonly Dictionary<string, HttpClient> _clients;
        public void Register(string name, HttpClient client)
        {
            _clients[name] = client;
        }
        
        public HttpClient Resolve(string name)
        {
            return _clients[name];
        }
    }
