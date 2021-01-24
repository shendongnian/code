    //Optional - called before the Configure method by the runtime
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {    
        app.UseCors(builder =>
           {
               builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
           });
       )
    }
