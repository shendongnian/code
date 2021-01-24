    // container type to hold the client and give it a name
    public class NamedHttpClient
    {
        public string Name { get; private set; }
        public HttpClient Client { get; private set; }
        public NamedHttpClient (string name, HttpClient client)
        {
            Name = name;
            Client = client;
        }
    }
    // factory to retrieve the named clients
    public class HttpClientFactory
    {
        private readonly IDictionary<string, HttpClient> _clients;
        public HttpClientFactory(IEnumerable<NamedHttpClient> clients)
        {
            _clients = clients.ToDictionary(n => n.Key, n => n.Value);
        }
        public HttpClient GetClient(string name)
        {
            if (_clients.TryGet(name, out var client))
                return client;
            // handle error
            throw new ArgumentException(nameof(name));
        }
    }
    // register those named clients
    services.AddSingleton<NamedHttpClient>(new NamedHttpClient("A", httpClientA));
    services.AddSingleton<NamedHttpClient>(new NamedHttpClient("B", httpClientB));
