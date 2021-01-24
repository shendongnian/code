    using Microsoft.Owin;
    using Owin;
    using System.Web.Http;
    using IdentityServer3.AccessTokenValidation;
    
    [assembly: OwinStartup(typeof(App.API.Test.Startup))]
    namespace App.API.Test
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
    
                app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = "https://identitydev.company.com/oidc/core",
                    RequiredScopes = new[] { "app_client_api" },
                    ValidationMode = ValidationMode.ValidationEndpoint
                });
    
                WebApiConfig.Register(config);
                app.UseWebApi(config);
            }
        }
    }
