    app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(15),
                CookieSecure = CookieSecureOption.Always,
                LoginPath = Microsoft.Owin.PathString.FromUriComponent("/Logout")
            });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                }
                );
