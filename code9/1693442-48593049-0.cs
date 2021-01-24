    Notifications = new OpenIdConnectAuthenticationNotifications()
    {
        RedirectToIdentityProvider = (context) =>
        {
            string login_hint = context.OwinContext.Authentication.AuthenticationResponseChallenge.Properties.Dictionary["login_hint"];
            context.ProtocolMessage.LoginHint = login_hint;
            return Task.FromResult(0);
         }
    }
