            public void ConfigureServices(IServiceCollection services)
            {
    
                var environment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
                           
    
                services.AddDataProtection()
                        .SetApplicationName($"my-app-{environment.EnvironmentName}")
                        .PersistKeysToFileSystem(new DirectoryInfo($@"{environment.ContentRootPath}\keys"));
    
               ...
    
            }
