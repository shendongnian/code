    public void Configure(IApplicationBuilder app)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles(); // For the wwwroot folder
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"build")),
            RequestPath = new PathString("/app")
    });
    }
