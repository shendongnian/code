    public static class FooMiddlewareExtensions
    {
        public static IApplicationBuilder UseFoo(this IApplicationBuilder builder, string path)
        {
            return builder.Map(path, b => b.UseMiddleware<FooMiddleware>());
        }
    }
