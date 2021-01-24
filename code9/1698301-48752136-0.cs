    public void ConfigureServices(IServiceCollection services)
    {
        // your current code goes here
        // ...
        services.AddScoped<ITestService, TestService>();
    }
