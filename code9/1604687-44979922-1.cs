    public class Startup
    {
    ....
    public void Configuration(IAppBuilder app)
    {
        ....
         private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseCustomOidcAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    AuthenticationType = "<name>",
                    Authority = "<OIDC server url>",
                    Caption = "<caption>",
                    ClientId = "<client id>",
                    ClientSecret = "<client secret>",
                    // might be https://localhost:44319/identity/<anything>
                    RedirectUri = "https://localhost:44319/identity/signin-customoidc",
                    ResponseType = "code",
                    Scope = "openid email profile address phone",
                    SignInAsAuthenticationType = signInAsType
                }                
            );
        }
        ....
    }
    ....
    }
