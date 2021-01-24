    static IDictionary<string, HttpClient> cache = new Dictionary<string, HttpClient>();
    
    public HttpClient Create(string endpoint) {
        HttpClient client = null;
        if(cache.TryGetValue(endpoint, out client)) {
            return client;
        }
    
        client = new HttpClient {
            BaseAddress = new Uri(endpoint),
        };
        cache[endpoint] = client;
    
        return client;
    }
