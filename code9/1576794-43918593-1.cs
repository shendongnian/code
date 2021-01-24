    public sealed class IpOptions
    {
        public string RemoteIp { get; set; }
    }
    public static class IpMiddlewareHandler
    {
        public static IAppBuilder UseIpMiddleware(this IAppBuilder app, IpOptions options)
        {
            app.Use<IpMiddleware>(options);
            return app;
        }
    }
