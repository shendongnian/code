    public void ConfigureServices(IServiceCollection services)
    {         
         // ... enter code here
         // RequestLocalizationOptions must to be configured 
         var cultureLt = new CultureInfo("LT");
         var cultureEn = new CultureInfo("EN");
         var supportedCultures = new[] { cultureEn, cultureLt };
            
         services.Configure<RequestLocalizationOptions>(options =>
         {
             options.SupportedCultures = supportedCultures;
             options.SupportedUICultures = supportedCultures;
         });
         // Add them to IServiceCollection
         services.AddLocalization();
         // ... enter code here
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // ... enter code here
        // add RequestLocalizationMiddleware to pipeline
        app.UseRequestLocalization();
        app.UseMvc...
    }
