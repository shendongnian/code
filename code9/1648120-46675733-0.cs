    if (request.IsPasswordGrantType())
    {
        // (...)
        if (useraccount != null && useraccount.Failcount <= AppConstants.AuthMaxAllowedFailedLogin)
        {
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme, OpenIdConnectConstants.Claims.Name, OpenIdConnectConstants.Claims.Role);
    
            identity.AddClaim(OpenIdConnectConstants.Claims.Subject, AppConstants.AuthSubjectClaim, OpenIdConnectConstants.Destinations.AccessToken);
            identity.AddClaim(OpenIdConnectConstants.Claims.Name, useraccount.Username, OpenIdConnectConstants.Destinations.AccessToken);
    
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                OpenIdConnectServerDefaults.AuthenticationScheme);
            // You have to grant the 'offline_access' scope to allow
            // OpenIddict to return a refresh token to the caller.
            ticket.SetScopes(OpenIdConnectConstants.Scopes.OfflineAccess);
    
            return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
        }
        // (...)
    }
