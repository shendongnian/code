    // Startup.cs
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
    
        app.MapWhen(IsAdminPath, builder => builder.RunProxy(new ProxyOptions
        {
            Scheme = "http",
            Host = "localhost",
            Port = "8081"
        }));
    
        ...
    
    }
    
    private static bool IsAdminPath(HttpContext httpContext)
    {
        return httpContext.Request.Path.Value.StartsWith(@"/admin/", StringComparison.OrdinalIgnoreCase);
    }
