    public void Configure(IApplicationBuilder app)
    {
        // ...
    
        // global policy - assign here or on each controller
        app.UseCors("CorsPolicy");
