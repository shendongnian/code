    public void ConfigureAuth(IAppBuilder app)
    {
        app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseOpenIdConnectAuthentication(
            new OpenIdConnectAuthenticationOptions
            {
                ClientId = clientId,
                Authority = Authority,
                PostLogoutRedirectUri = redirectUri,
                RedirectUri = redirectUri,
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    //
                    // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                    //
                    AuthorizationCodeReceived = OnAuthorizationCodeReceived,
                    AuthenticationFailed = OnAuthenticationFailed,
                    RedirectToIdentityProvider= OnRedirectToIdentityProvider,
                    MessageReceived= OnMessageReceived,
                    SecurityTokenReceived= OnSecurityTokenReceived,
                },
            });
        app.UseWindowsAzureActiveDirectoryBearerAuthentication(new Microsoft.Owin.Security.ActiveDirectory.WindowsAzureActiveDirectoryBearerAuthenticationOptions
        {
            Audience = "",
            Tenant = "",
        });
    }
