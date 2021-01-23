    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore()
                .AddCors()
                (...)
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //Cors
        app.UseCors(builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowCredentials();
            //corsBuilder.WithOrigins("http://localhost:56573");
         });
    }
