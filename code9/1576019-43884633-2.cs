    class Test
    {
        private static CookieContainer cookieContainer;
        private static HttpClientHandler clienthandler;
        private HttpClient client;
    
        public Test()
        {
            cookieContainer = new CookieContainer();
            clienthandler = new HttpClientHandler { AllowAutoRedirect = true, UseCookies = true, CookieContainer = cookieContainer };
            client = new HttpClient(clienthandler);
        }
    }
