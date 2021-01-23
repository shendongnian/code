    public static HttpConfiguration HttpConfiguration { get; private set; }
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration();
            LoggingConfig.RegisterLogger();
            HttpConfiguration.DependencyResolver = new UnityDependencyResolver(
                UnityConfig.GetConfiguredContainer());
            ConfigureOAuth(app);
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(HttpConfiguration);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(HttpConfiguration);
        }
