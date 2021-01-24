    public void Configure(IApplicationBuilder app){...
    // content is physically stored at /site/abc on an Azure Web App, not /site/wwwroot/abc
    string path = Path.Combine(Directory.GetCurrentDirectory(), "abc");
    PhysicalFileProvider fileProvider = new PhysicalFileProvider(path); 
    
    DefaultFilesOptions options = new DefaultFilesOptions 
        {
            FileProvider = fileProvider, 
            RequestPath = "/ABC",
        }; 
    options.DefaultFileNames.Add("index.html");
    app.UseDefaultFiles(options);
    
    app.UseStaticFiles(new StaticFileOptions
                       {
                           FileProvider = fileProvider,
                           RequestPath = "/ABC"
                       });
    }
