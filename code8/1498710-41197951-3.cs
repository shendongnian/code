    public void Configure(IApplicationBuilder app, IHostingEnvironment env,
        ILoggerFactory loggerFactory)
    {
        Container.RegisterSingleton(loggerFactory);
        ...
    }
