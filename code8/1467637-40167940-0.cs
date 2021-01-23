    public void Configuration(IAppBuilder app)
    {
        var config = GlobalConfiguration.Configuration;
        new MobileAppConfiguration()
            .AddPushNotifications()
            .ApplyTo(config);
        MobileAppSettingsDictionary settings = config
            .GetMobileAppSettingsProvider()
            .GetMobileAppSettings();
        // Local Debugging
        if (string.IsNullOrEmpty(settings.HostName))
        {
            app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions()
            {
                SigningKey = ConfigurationManager.AppSettings["authSigningKey"],
                ValidAudiences = new[] { ConfigurationManager.AppSettings["authAudience"] },
                ValidIssuers = new[] { ConfigurationManager.AppSettings["authIssuer"] },
                TokenHandler = new AppServiceTokenHandlerWithCustomClaims(config)
            });
        }
        // Azure
        else
        {
            var signingKey = GetSigningKey();
            string hostName = GetHostName(settings);
            app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
            {
                SigningKey = signingKey,
                ValidAudiences = new[] { hostName },
                ValidIssuers = new[] { hostName },
                TokenHandler = new AppServiceTokenHandlerWithCustomClaims(config)
            });
        }
        //Authenticate stage handler in OWIN Pipeline
        app.Use((context, next) =>
        {
            return next.Invoke();
        });
        app.UseStageMarker(PipelineStage.Authenticate);
    }
    private static string GetSigningKey()
    {
        // Check for the App Service Auth environment variable WEBSITE_AUTH_SIGNING_KEY,
        // which holds the signing key on the server. If it's not there, check for a SigningKey
        // app setting, which can be used for local debugging.
 
        string key = Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY");
 
        if (string.IsNullOrWhiteSpace(key))
        {
            key = ConfigurationManager.AppSettings["SigningKey"];
        }
 
        return key;
    }
 
    private static string GetHostName(MobileAppSettingsDictionary settings)
    {
        return string.Format("https://{0}/", settings.HostName);
    }
