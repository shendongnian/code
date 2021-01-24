    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Other code here…
        app.UseAuthentication();
        app.UseMvc();
    }
