    public class GoodHttpClient
    {
        // OK
        private static readonly _httpClient HttpClient;
    
        static GoodHttpClient()
        {
            _httpClient = new HttpClient();
        }
    }
