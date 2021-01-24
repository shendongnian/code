    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseUrlRewriteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UrlRewriteMiddleware>();
        }
    }
