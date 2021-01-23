    public void Configure(IApplicationBuilder app)
    {
        app.UseMiddleware<EndRequestMiddleware>();
        // Register other middelware here such as:
        app.UseMvc();
    }
