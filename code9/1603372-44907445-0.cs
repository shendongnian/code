    app.UseOpenIdConnectAuthentication(
    new OpenIdConnectAuthenticationOptions
    {
        Authority = "https://idp.io",
        ClientId = "clientid",
        RedirectUri = "https://mywebsite.io",
        ResponseType = "code id_token token",
        Scope = "openid profile",
        SignInAsAuthenticationType = "Cookies",
        UseTokenLifetime = false,
        Notifications = new OpenIdConnectAuthenticationNotifications
        {
            SecurityTokenValidated = notification =>
            {
                notification.AuthenticationTicket.Properties.RedirectUri = RewriteToPublicOrigin(notification.AuthenticationTicket.Properties.RedirectUri);
                return Task.CompletedTask;
            }
        }
    });
