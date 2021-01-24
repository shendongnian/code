    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(); //adds the auth services
        services.AddMvc();
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
    
        app.UseQueryStringAuthentication(); //add our query string auth
    
        //add mvc last
        app.UseMvc();
    }
