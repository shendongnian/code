    public void ConfigureServices(IServiceCollection services)
    {
        ...
        // register to the DI container so it can be injected in the AuthController constructor.
        services.AddSingleton<OpenIdConnectPostConfigureOptions>();
        ...
    }
