    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("es") };
            options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(locOptions.Value);
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();
        app.UseMvcWithDefaultRoute();
    }
