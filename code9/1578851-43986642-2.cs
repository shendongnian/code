    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Example",
                builder => builder.WithOrigins("http://www.example.com")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
        });
        services.AddMvc();
        //other configure stuff
    }
    
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseCors("AllowAll"); //Default
        app.UseMvcWithDefaultRoute();
    }
