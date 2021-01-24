    public void ConfigureServices(IServiceCollection services)
            {
                //removed other configurations
                services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
                // Register cultures here
                services.Configure<RequestLocalizationOptions>(
                    opts =>
                    {
                        var supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-GB"),
                            new CultureInfo("en-US"),
                            new CultureInfo("fr-FR"),
                        };
                        opts.DefaultRequestCulture = new RequestCulture("en-US");
                        opts.SupportedCultures = supportedCultures;
                        opts.SupportedUICultures = supportedCultures;
                    });
                services.AddMvc()
               
    // other registrations
            }
            
    public void Configure(IApplicationBuilder app,
                IHostingEnvironment env)
    {
                           
    // Access the registered cultures here and set it to the app
    
  app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
                app.UseMvc();
    }
