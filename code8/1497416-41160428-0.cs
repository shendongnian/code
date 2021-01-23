    public void Configuration(IAppBuilder app)
    {
        HttpConfiguration config = new HttpConfiguration();
        // Swagger
        SwaggerConfig.Register(config);
        // Authentication token
        ConfigureOAuth(app);
        // SignalR configuration
        ConfigureSignalR(app);
        // Register routes
        WebApiConfig.Register(config);
        // Allow cross-domain requests
        app.UseCors(CorsOptions.AllowAll);
        app.UseWebApi(config);
    }
