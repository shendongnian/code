    public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
    
            public void ConfigureOAuth(IAppBuilder app)
            {
                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new SimpleAuthorizationServerProvider()
                };
    
                // Token Generation
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }
        }
    
        public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
    
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
    
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    
                if (context.Request.Method != "POST")
                {
                    context.SetError("invalid_request", "Invalid request");
                    return;
                }
    
                using (AuthRepository _repo = new AuthRepository())
                {
                    IdentityUser user = await _repo.FindUser(context.UserName, context.Password);
    
                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }
                }
    
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
    
                context.Validated(identity);
    
            }
        }
