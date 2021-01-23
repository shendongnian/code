    public void Configure(IApplicationBuilder app, IHostingEnvironment e, ILoggerFactory f)
    {
        var accesr = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
        container.RegisterSingleton<IUserContext>(new AspNetSessionUserContextAdapter(accesr));
        container.Register<IAppAdminAuthorization, SessionAppAdminAuthorization>();
        // ...
    }
