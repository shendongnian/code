      public sealed class HttpClientSingleton
    {
        private static readonly Lazy<HttpClient> lazy = new Lazy<HttpClient>(() => new HttpClient());
        public static HttpClient Instance { get { return lazy.Value; } }
        private HttpClientSingleton()
        {
        }
    }
