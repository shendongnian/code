    public void Configure(IApplicationBuilder app)
    {
        ...
        app.UseMvcWithDefaultRoute();
        app.UseStaticFiles();
    }
