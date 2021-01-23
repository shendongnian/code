    public static class ApiKeyExtensions {
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
