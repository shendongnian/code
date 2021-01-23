    public class SignServiceWrapper
    {
        private static string _webServiceUrl;
        private  BrokerClientClient client;
    
        public SignServiceWrapper(string webServiceUrl)
        {
            _webServiceUrl = webServiceUrl;
        }
    
        public Task<loginResponse> LoginAsync(loginRequest request)
        {
            ClientGenerator.WebServiceUrl = _webServiceUrl;
            ClientGenerator.InitializeService();
            client = ClientGenerator.ServiceClient;
            return client.loginAsync(request);
        }
    
        // ...
    }
