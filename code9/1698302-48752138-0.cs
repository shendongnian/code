    public void ConfigureServices(IServiceCollection services)
    {
        //Snip
        services.AddScoped<ITestService, TestService>();
    }
