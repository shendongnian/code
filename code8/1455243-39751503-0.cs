    Notifications = new OpenIdConnectAuthenticationNotifications
    {
        SecurityTokenValidated = x =>
        {
            x.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", x.ProtocolMessage.AccessToken));
            return Task.FromResult(0);
        }
    }
