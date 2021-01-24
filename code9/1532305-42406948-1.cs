    public void ConfigureAuth(IAppBuilder app)
    {
        app.MapWhen(context => !IsDataPath(context.Request), appBuilder =>
        {
            appBuilder.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions());
            appBuilder.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        SecurityTokenValidated = (context) =>
                        {
                            ...
                        },
                        AuthenticationFailed = (context) =>
                        {
                            ...
                        },
                    }
                });
            appBuilder.MapSignalR();
        });
    }
