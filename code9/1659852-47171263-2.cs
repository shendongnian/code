    public void ConfigureServices(IServiceCollection services)
    {
         services.AddSingleton(new PingService());
         services.AddMvc();
         //rest goes here
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env,  ILoggerFactory loggerFactory)
    {
        app.UseSoapEndpoint(path: "/PingService.svc", binding: new BasicHttpBinding());
        app.UseMvc();
        //rest goes here
    }
