    public static class RequestTimestampMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimestamp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimestampMiddleware>();
        }
    }
