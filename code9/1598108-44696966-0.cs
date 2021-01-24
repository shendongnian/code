     public class Startup {
        public void Configuration(IAppBuilder app) {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
            var config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            //Middleware for security. This will introspect the incoming reference token
            IdentityServerBearerTokenAuthenticationOptions _options = new IdentityServerBearerTokenAuthenticationOptions {
                Authority = ConfigurationManager.AppSettings["IdentityServerURI"],
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "xxxxxadmin" },
                ClientId = "xxxxxadmin",
                ClientSecret = "api-secret",
                EnableValidationResultCache = true,
                ValidationResultCacheDuration =  TimeSpan.FromMinutes(10)                
            };
            app.UseIdentityServerBearerTokenAuthentication(_options);
           
            //Boots up the application
            Bootstraper.BootUp(config, app);
        }
    }
