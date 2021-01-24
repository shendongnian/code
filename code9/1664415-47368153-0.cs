    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                                                               ILoggerFactory loggerFactory)
    {
         // Your existing code goes here
         app.UseStaticFiles();
         app.UseStaticFiles(new StaticFileOptions()
         {
            FileProvider = new PhysicalFileProvider(
                  Path.Combine(Directory.GetCurrentDirectory(), @"Content")),
            RequestPath = new PathString("/Images")
         });
    }
