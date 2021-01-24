    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
    
        services.AddMvc()
            .AddViewLocalization(
                Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.SubFolder,
                opts => { opts.ResourcesPath = "Resources"; }
            )
            .AddDataAnnotationsLocalization();
    
        services.Configure<RequestLocalizationOptions>(opts =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"), 
                ...               
            };
            opts.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
            opts.SupportedCultures = supportedCultures;
            opts.SupportedUICultures = supportedCultures;
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseRequestLocalization();
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
        });
    }
