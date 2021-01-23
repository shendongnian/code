    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<AzureStorageConfig>(Configuration.GetSection("AzureStorageConfig"));
        services.AddSingleton<AzureBlobStorageClient>();
        services.AddMvc();
    }
