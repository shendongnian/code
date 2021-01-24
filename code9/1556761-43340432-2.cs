    public void ConfigureServices(IServiceCollection services)
    {
        //Add our IFileServerProvider implementation as a singleton
        services.AddSingleton<IFileServerProvider>(new FileServerProvider(
            new List<FileServerOptions>
            {
                new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(@"D:\\somepath"),
                    RequestPath = new PathString("/OtherPath"),
                    EnableDirectoryBrowsing = true
                },
                new FileServerOptions
                {
                    FileProvider = new PhysicalFileProvider(@"\\server\path"),
                    RequestPath = new PathString("/MyPath"),
                    EnableDirectoryBrowsing = true
                }
            }));
        // Add framework services.
        services.AddMvc();
    }
