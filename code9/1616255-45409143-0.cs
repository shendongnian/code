    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ...
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                ...
                RedirectToIdentityProvider = notification =>
                {
                    var dict = notification.OwinContext.Authentication.AuthenticationResponseChallenge.Properties.Dictionary;
                    if (dict.ContainsKey("DomainHint"))
                    {
                        notification.ProtocolMessage.DomainHint = dict["DomainHint"];
                    }
                    return Task.FromResult(0);
                }
            }
        }
    );
