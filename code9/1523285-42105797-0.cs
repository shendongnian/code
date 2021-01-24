    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = authority,
       
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                RedirectToIdentityProvider=context=>
                {                                  
                    string appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                    string currentUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.Path;
                    context.ProtocolMessage.RedirectUri = currentUrl;
                    context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                    return Task.FromResult(0);
                }
            }
        });
 
