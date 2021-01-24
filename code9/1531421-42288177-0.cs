    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions
        {
            ClientId = SettingsHelper.ClientId,
            Authority = SettingsHelper.Authority,                
            Notifications = new OpenIdConnectAuthenticationNotifications()
            {
                //
                // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                AuthorizationCodeReceived = (context) =>
                {
                    var code = context.Code;
                    ClientCredential credential = new ClientCredential(SettingsHelper.ClientId, SettingsHelper.ClientSecret);
                    String UserObjectId = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    AuthenticationContext authContext = new AuthenticationContext(SettingsHelper.Authority, new ADALTokenCache(UserObjectId));
                    authContext.AcquireTokenByAuthorizationCode(code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, SettingsHelper.AADGraphResourceId);
                    //authContext.TokenCache.Clear();
                    return Task.FromResult(0);
                }
            }
        });
