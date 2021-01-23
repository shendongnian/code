    public void ConfigureServices(IServiceCollection services)
    {
      services.AddQuartz(new QuartezOptions {});
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.UseQuartz();
    }
