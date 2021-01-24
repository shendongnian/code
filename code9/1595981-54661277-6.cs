    public void ConfigureServices(IServiceCollection services)
    {
        ...
        string connectionString = _configuration.GetConnectionString("appDbConnection");
        services
            .AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddEFConfigurationStore(connectionString)
            ...;
        ...
    }
