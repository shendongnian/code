    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = authority,
            PostLogoutRedirectUri = postLogoutRedirectUri,
            RedirectUri = postLogoutRedirectUri,
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                AuthenticationFailed = context => 
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Error?message=" + context.Exception.Message);
                    return Task.FromResult(0);
                }
            }
        });
