    public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                          ILoggerFactory loggerFactory, IServiceProvider provider) {
        //.............
        var dbContext = provider.GetService<iProfiler_ControlsContext>();
        options.SecurityTokenValidators.Add(new MyTokenHandler(dbContext));
        app.UseJwtBearerAuthentication(options);
       //..............
    }
