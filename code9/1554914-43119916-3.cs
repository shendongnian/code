    public IHttpClientAccessor 
    {
        HttpClient HttpClient { get; }
    }
    public DefaultHttpClientAccessor : IHttpClientAccessor
    {
        public HttpClient Client { get; }
        public DefaultHttpClientAccessor()
        {
            Client = new HttpClient();
        }
    }
