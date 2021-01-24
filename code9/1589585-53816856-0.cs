    public void ConfigureServices(IServiceCollection services)
    {
        // Add service and create Policy with options
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials() );
        });
        
        
        services.AddMvc(); 
    }
