    public class MyHttpClientWrapper
    {
    	private static readonly object ThreadLock = new object();
        private static HttpClient _httpClient;
        private readonly TokenManager _tokenManager;
    
        public Client
        {
    		get
    		{
    			if (_httpClient != null) return _httpClient;
    			
    			// Initialize http client for the first time, and lock for thread-safety
    			lock (ThreadLock)
    			{
    				// Double check
    				if (_httpClient != null) return _httpClient;
    			
    				_httpClient = new HttpClient();
    				InitClient(_httpClient);
    				return _httpClient;
    			}
    			
    		}
    		set
    		{
    			// primarily used for unit-testing
    			_httpClient = value;
    			InitClient(_httpClient);
    		}
        }
    	
    	private void InitClient(HttpClient httpClient)
    	{
    		httpClient.BaseAddress = new Uri("https://someapp/api/");
    		httpClient.DefaultRequestHeaders.Accept.Add(
    			new MediaTypeWithQualityHeaderValue("application/json"));
    	}
    	
    
        public HttpServiceClient(TokenManager tokenManager)
        {
            _tokenManager = tokenManager;        
        }
    
        public string GetDataByQuery(string query)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "amx", _tokenManager.GetNewAuthorizationCode());
    
            var response = _httpClient.GetAsync(query).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    
    }
