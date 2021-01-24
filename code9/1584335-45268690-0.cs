    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CommunicatorContext>();
            // rest of your code
        }
    }
