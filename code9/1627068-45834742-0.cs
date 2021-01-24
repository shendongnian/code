    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore()
            .AddViews()
            .AddRazorViewEngine()
            .AddRazorPages();
    }
