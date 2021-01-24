    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = authority,
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                AuthenticationFailed = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Error?message=" + context.Exception.Message);
                    return Task.FromResult(0);
                },        
                RedirectToIdentityProvider = context =>
                  {
                      string appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                      string currentUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.Path;
                      context.ProtocolMessage.RedirectUri = currentUrl;
                      context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                      return Task.FromResult(0);
                  }
            }    
        });
