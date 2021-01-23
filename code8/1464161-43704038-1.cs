    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        //Or if you want to chose what to include
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
            builder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url.
         });
    }
