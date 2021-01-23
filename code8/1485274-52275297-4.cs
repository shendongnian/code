    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddHttpClient<IMyCustomHttpClientFactory, MyCustomHttpClientFactory>()
            .SetHandlerLifetime(...)
            .AddPolicyHandler(....);
    }
