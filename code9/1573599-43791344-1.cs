    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        AppDependencyResolver.Init(app.ApplicationServices);
        //other configure code
    }
