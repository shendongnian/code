    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
             ILoggerFactory loggerFactory, IApplicationLifetime appLifetime,
             IServiceProvider serviceProvider)
    {
        ...
        var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
        // and extend ConfigureAuth
        ConfigureAuth(app, httpContextAccessor);
        ...
    }
