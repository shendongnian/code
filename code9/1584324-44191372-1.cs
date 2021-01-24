    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                          ILoggerFactory loggerFactory, IServiceProvider serviceProvider) {
        //...Other code removed for brevity
        app.UseMvc();
        //resolve dependencies
        var dbContext = serviceProvider.GetService<CommunicatorContext>();
        var ldapService = serviceProvider.GetService<ILdapService>();
        DbInitializer.Initialize(dbContext, ldapService);
    }
