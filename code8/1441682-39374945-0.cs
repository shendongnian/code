    public class MyHttpClientWrapper
    {
        private static readonly HttpClient _httpClient;
        private readonly TokenManager _tokenManager;
    
        static MyHttpClientWrapper()
        {
            // Initialize the static http client:
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://someapp/api/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
    		    new MediaTypeWithQualityHeaderValue("application/json"));
        }
    
        public HttpServiceClient(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;        
        }
    
        public string GetDataByQuery(string query)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "amx", _tokenManager.GetNewAuthorizationCode());
    
            var response = _httpClient.GetAsync(query).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    
    }
