        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .MapApiControllers()
                .ApplyTo(config);
            config.MapHttpAttributeRoutes();
            // Use Entity Framework Code First to create database tables based on your DbContext
            //Database.SetInitializer(new EducaterAPIDevInitializer());
            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<EducaterAPIDevContext>(null);
            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
            if (string.IsNullOrEmpty(settings.HostName))
            {
                var options = new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                };
                app.UseAppServiceAuthentication(options);
            }
            app.UseWebApi(config);
        }
