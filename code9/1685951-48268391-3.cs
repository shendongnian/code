    using Microsoft.Owin;
    using Owin;
    using System.Web.Http;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Jwt;
    
    [assembly: OwinStartup(typeof(solution.Startup))]
    
    namespace solution
    {
      public class Startup
      {
        public void Configuration(IAppBuilder app)
        {
          app.MapSignalR();
          HttpConfiguration config = new HttpConfiguration();
          config.MapHttpAttributeRoutes();
          ConfigureOAuth(app);
          app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
          app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
          var issuer = "issuer";
          var audience = "audience";
          var secret = JwtSecurityKey.Create("SecurityKey").GetSymmetricKey();
    
          // Api controllers with an [Authorize] attribute will be validated with JWT
          var option =
              new JwtBearerAuthenticationOptions
              {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                  {
                            new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                  }
              };
          app.UseJwtBearerAuthentication(
                option
            );
        }
      }
    }
