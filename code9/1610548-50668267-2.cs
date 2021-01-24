    using ResourceLibrary;
    ...
    
    public void ConfigureServices(IServiceCollection services) {
        ...
        services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
     
        services.Configure<RequestLocalizationOptions>(options =>
                {
                    CultureInfo[] supportedCultures = new[]
                    {
                        new CultureInfo("en"),
                        new CultureInfo("he")
                    };
    
                    options.DefaultRequestCulture = new RequestCulture("en");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                 });
         ...
         }
    
         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
            ...
            app.UseRequestLocalization(); //before app.UseMvc()
            ...
            }
