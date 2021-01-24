    public static class QueryStringAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseQueryStringAuthentication(this IApplicationBuilder appBuilder)
        {
            if (appBuilder == null)
                throw new ArgumentNullException(nameof(appBuilder));
    
            var options = new QueryStringAuthOptions();
            return appBuilder.UseQueryStringAuthentication(options);
        }
    
        public static IApplicationBuilder UseQueryStringAuthentication(this IApplicationBuilder appBuilder, Action<QueryStringAuthOptions> optionsAction)
        {
            if (appBuilder == null)
                throw new ArgumentNullException(nameof(appBuilder));
    
            var options = new QueryStringAuthOptions();
            optionsAction?.Invoke(options);
            return appBuilder.UseQueryStringAuthentication(options);
        }
    
        public static IApplicationBuilder UseQueryStringAuthentication(this IApplicationBuilder appBuilder, QueryStringAuthOptions options)
        {
            if (appBuilder == null)
                throw new ArgumentNullException(nameof(appBuilder));
    
            if (options == null)
                throw new ArgumentNullException(nameof(options));
    
            return appBuilder.UseMiddleware<QueryStringAuthMiddleware>(Options.Create(options));
        }
    }
