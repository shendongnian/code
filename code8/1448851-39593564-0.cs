    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(_configFolderPath));
    }
