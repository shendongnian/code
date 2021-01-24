    public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new EmbeddedFileProvider(typeof(Startup).Assembly, typeof(Startup).Namespace + ".assets"),
                 RequestPath = new PathString("/assets")
            });
        }
