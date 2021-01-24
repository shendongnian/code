    public void Configure(IApplicationBuilder app)
    {
        app.UsePathBase("/site");
        // …
        app.UseMvc();
    }
