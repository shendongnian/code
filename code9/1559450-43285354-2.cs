     public class OwinStartup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
            var container = SimpleInjectorConfig.Configure();
            //allows scoped instances to be resolved during OWIN request
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });
            var config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };
            ConfigureOAuth(app, config);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);  
        }
        private static void ConfigureOAuth(IAppBuilder app, HttpConfiguration config)
        {
            app.CreatePerOwinContext(
                () => (AppUserManager)config.DependencyResolver.GetService(
                    typeof(AppUserManager)));
            var options = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AppAuthProvider(),
                //TODO: Change in production.
                AllowInsecureHttp = true,
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
