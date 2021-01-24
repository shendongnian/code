    public static class UserDestroyerMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserDestroyer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserDestroyerMiddleware>();
        }
    }
