    public static class ServiceCollectionExtensions
    {
        public static void AddHttpClient(this IServiceCollection @this, Action<HttpClientOptions> configure = null)
        {
            var options = new HttpClientOptions();
            
            if (configure != null)
            {
                configure(options);
            }
            @this.AddSingleton<HttpClient>(options);
        }
    }
