    public void ConfigureServices(IServiceCollection services)
    {
        ...
        // Your resources folder
        services.AddLocalization(options => options.ResourcesPath = "Resources");
    }
    
    public void Configure(IApplicationBuilder app)
    {
        ...
        // Languages you support in your application
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("xx-YY")
        };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            // default language
            DefaultRequestCulture = new RequestCulture("en-US", "en-US");,
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });
    }
