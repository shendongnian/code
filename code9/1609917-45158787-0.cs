    app.UseWindowsAzureActiveDirectoryBearerAuthentication(
        new WindowsAzureActiveDirectoryBearerAuthenticationOptions
        {
            Audience = ConfigurationManager.AppSettings["ida:Audience"],
            Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
    });
    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = Authority,
            Notifications = new OpenIdConnectAuthenticationNotifications()
            {
                RedirectToIdentityProvider = (context) =>
                {
                    // This ensures that the address used for sign in and sign out is picked up dynamically from the request
                    // this allows you to deploy your app (to Azure Web Sites, for example)without having to change settings
                    // Remember that the base URL of the address used here must be provisioned in Azure AD beforehand.
                    string appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                    context.ProtocolMessage.RedirectUri = appBaseUrl + "/";
                    context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                    return Task.FromResult(0);
                },
                AuthenticationFailed = (context) =>
                {
                    // Suppress the exception if you don't want to see the error
                    context.HandleResponse();
                    return Task.FromResult(0);
                }
            },
            TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = false,
            }
        });
