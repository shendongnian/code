    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            // The `Authority` represents the v2.0 endpoint - https://login.microsoftonline.com/common/v2.0
            // The `Scope` describes the initial permissions that your app will need.  See https://azure.microsoft.com/documentation/articles/active-directory-v2-scopes/                    
            ClientId = clientId,
            //Authority = String.Format(CultureInfo.InvariantCulture, aadInstance, "adnewfei.onmicrosoft.com", "/v2.0"),
            Authority = String.Format(CultureInfo.InvariantCulture, aadInstance, "common", "/v2.0"),
            RedirectUri = redirectUri,
            Scope = "openid email profile offline_access Mail.Read User.Read",
            PostLogoutRedirectUri = redirectUri,
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
           
            },
            Notifications = new OpenIdConnectAuthenticationNotifications
            {
                // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                AuthorizationCodeReceived = async (context) =>
                {
                    var code = context.Code;
                    string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    ConfidentialClientApplication cca = new ConfidentialClientApplication(clientId, redirectUri,
                       new ClientCredential(appKey),
                       new MSALSessionCache(signedInUserID, context.OwinContext.Environment["System.Web.HttpContextBase"] as HttpContextBase));
                    string[] scopes = { "Mail.Read User.Read" };
                    try
                    {
                        AuthenticationResult result = await cca.AcquireTokenByAuthorizationCodeAsync(scopes, code);
                    }
                    catch (Exception eee)
                    {
                    }
                },
                AuthenticationFailed = (notification) =>
                {
                    notification.HandleResponse();
                    notification.Response.Redirect("/Error?message=" + notification.Exception.Message);
                    return Task.FromResult(0);
                },
                SecurityTokenValidated = (context) => {
                    if (context.AuthenticationTicket.Identity.Claims.First(claim => claim.Type == "preferred_username").Value == "xxxx@hotmail.com")
                    {
                        
                    }
                    else
                    {
                        throw new System.IdentityModel.Tokens.SecurityTokenValidationException();
                    }
                    return Task.FromResult(0);
                },
            },
        });
