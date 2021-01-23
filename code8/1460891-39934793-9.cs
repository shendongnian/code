    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ...
        RolesData.SeedRoles(app.ApplicationServices).Wait();
    }
