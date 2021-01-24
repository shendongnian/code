    .AddOpenIdConnect(options =>
    {
        options.Authority = String.Format(Configuration["AzureAd:AadInstance"], Configuration["AzureAd:Tenant"]);
        options.ClientId = Configuration["AzureAd:ClientId"];
        options.ResponseType = "code id_token";     
    });
    options.Events = new OpenIdConnectEvents
    {
        OnAuthorizationCodeReceived = async context =>
        {
            var credential = new ClientCredential(context.Options.ClientId, context.Options.ClientSecret);
            var authContext = new AuthenticationContext(context.Options.Authority);
            var authResult=await authContext.AcquireTokenByAuthorizationCodeAsync(context.TokenEndpointRequest.Code,
                new Uri(context.TokenEndpointRequest.RedirectUri, UriKind.RelativeOrAbsolute), credential, context.Options.Resource);
            context.HandleCodeRedemption(authResult.AccessToken, context.ProtocolMessage.IdToken);
        },
    };
