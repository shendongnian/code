    class ControllerA
    {
        private readonly HttpClient _httpClient;
        public ControllerA(IHttpClientFactory factory)
        {
            _httpClient = factory.Resolve("ClientA");
        }
    }
