    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore()
            .AddAuthorization()
            .AddRazorPages();
    }
