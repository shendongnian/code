    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        // Register the Swagger generator, defining one or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        });
    }
    public void Configure(IApplicationBuilder app)
    {
        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();
    
        app.UseMvc();
    }
