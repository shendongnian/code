    public void Configuration(IAppBuilder app)
                {
       app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions {});
            
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "oidc",
                SignInAsAuthenticationType = "Cookies",
                Authority = "http://localhost:5000/",
                RedirectUri = "http://localhost:44301/signin-oidc",
                PostLogoutRedirectUri = "http://localhost:44301/signout-callback-oidc",
                ClientId = "CP",
                ResponseType = "id_token",
                Scope = "openid profile",
                UseTokenLifetime = false,
                RequireHttpsMetadata = false,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = (context) =>
                    {
                        var identity = context.AuthenticationTicket.Identity;
                        var name = identity.Claims.FirstOrDefault(c => c.Type == identity.NameClaimType)?.Value;
            
                        return Task.FromResult(0);
                    }
                }
            });
        }
