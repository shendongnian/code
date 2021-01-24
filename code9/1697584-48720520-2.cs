    public sealed class HttpService
        {
            private static readonly HttpClient instance = new HttpClient();
        
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static HttpService()
            {
            }
        
            private HttpService()
            {
            }
        
            public static HttpService Instance
            {
                get
                {
                    return instance;
                }
            }
        }
