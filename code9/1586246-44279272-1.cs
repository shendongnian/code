      public static void ConfigureMobileApp(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
    
                config.Services.Add(typeof(IExceptionLogger),
        new TraceSourceExceptionLogger(new
        TraceSource("MyTraceSource", SourceLevels.All)));
    
    
                new MobileAppConfiguration()
                    .UseDefaultConfiguration()
                    .ApplyTo(config);
    
                // Use Entity Framework Code First to create database tables based on your DbContext
                Database.SetInitializer(new MobileServiceInitializer());
    
                MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
    
                if (string.IsNullOrEmpty(settings.HostName))
                {
                    app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                    {
                        // This middleware is intended to be used locally for debugging. By default, HostName will
                        // only have a value when running in an App Service application.
                        SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                        ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                        ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                        TokenHandler = config.GetAppServiceTokenHandler()
                    });
                }
    
                app.UseWebApi(config);
            }
