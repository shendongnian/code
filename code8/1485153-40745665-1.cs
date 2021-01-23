    public void ConfigureServices(IServiceCollection services)
    {
        // You need to register IHttpContextAccessor.
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // ...
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment e, ILoggerFactory f)
    {
        container.RegisterSingleton(
            app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        container.Register<IAppAdminAuthorization, SessionAppAdminAuthorization>();
        // ...
    }
