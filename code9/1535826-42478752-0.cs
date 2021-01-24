    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = clientId,
            Authority = authority,
            PostLogoutRedirectUri = postLogoutRedirectUri,
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                AuthenticationFailed = context => 
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Error?message=" + context.Exception.Message);
                    return Task.FromResult(0);
                }
                ,
                SecurityTokenValidated = context =>
                {
                    //you can use the Azure AD Graph to read the custom data extension here and add it to the claims 
                    context.AuthenticationTicket.Identity.AddClaim(new System.Security.Claims.Claim("AddByMe", "test"));
                    return Task.FromResult(0);
                }
        });
