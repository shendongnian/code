        private HttpClient m_httpClient = new HttpClient();
        private HttpClient MyHttpClient
        {
            get
            {
                if ( m_httpClient==null )
                {
                    m_httpClient = new HttpClient();
                }
                return m_httpClient;
            }
        }
        public async void GetJSON()
        {
            // var client = new HttpClient();
            var client = MyHttpClient;
