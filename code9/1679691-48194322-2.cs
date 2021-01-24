        public static class AdAuthorizationMiddlewareExtension
        {
            public static IApplicationBuilder UseAdAuthorizationMiddleware(
                this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<AdAuthorizationMiddleware>();
            }
        }
