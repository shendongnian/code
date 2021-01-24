    public IHttpClientAccessor 
    {
        HttpClient HttpClient { get; }
    }
    public DefaultHttpClientAccessor : IHttpClientAccessor
    {
        private readonly HttpClient client;
        public DefaultHttpClientAccessor()
        {
            client = new HttpClient();
        }
    }
