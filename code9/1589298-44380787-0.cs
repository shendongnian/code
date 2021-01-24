    new OpenIdConnectAuthenticationOptions
    {
        // For each policy, give OWIN the policy-specific metadata address, and
        // set the authentication type to the id of the policy
        MetadataAddress = String.Format(aadInstance, tenant, policy),
        AuthenticationType = policy,
        // These are standard OpenID Connect parameters, with values pulled from web.config
        ClientId = clientId,
        RedirectUri = redirectUri,
        PostLogoutRedirectUri = redirectUri,
        Notifications = new OpenIdConnectAuthenticationNotifications
        {
            AuthenticationFailed = AuthenticationFailed,
            RedirectToIdentityProvider= OnRedirectToIdentityProvider,
            MessageReceived= OnMessageReceived
        },
        Scope = "openid",
        ResponseType = "id_token",
        // This piece is optional - it is used for displaying the user's name in the navigation bar.
        TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "name",
        },
    };
    private Task OnRedirectToIdentityProvider(RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
    {
        var stateQueryString = notification.ProtocolMessage.State.Split('=');
        var protectedState = stateQueryString[1];
        var state = notification.Options.StateDataFormat.Unprotect(protectedState);
        state.Dictionary.Add("mycustomparameter", "myvalue");
        notification.ProtocolMessage.State = stateQueryString[0] + "=" + notification.Options.StateDataFormat.Protect(state);
        return Task.FromResult(0);
    }
    private Task OnMessageReceived(MessageReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
    {
        string mycustomparameter;
        var protectedState = notification.ProtocolMessage.State.Split('=')[1];
        var state = notification.Options.StateDataFormat.Unprotect(protectedState);
        state.Dictionary.TryGetValue("mycustomparameter", out mycustomparameter);
        return Task.FromResult(0);
    }
