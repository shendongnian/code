        // Configure the OWIN pipeline to use cookie auth.
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        // Configure the OWIN pipeline to use OpenID Connect auth.
        var openIdConnectOptions = new OpenIdConnectOptions
        {
             ClientId = "{Your-ClientId}",
             ClientSecret = "{Your-ClientSecret}",
             Authority = "http://login.microsoftonline.com/{Your-TenantId}/v2.0",
             ResponseType = OpenIdConnectResponseType.CodeIdToken,
             TokenValidationParameters = new TokenValidationParameters
             {
                 NameClaimType = "name",
             },
             GetClaimsFromUserInfoEndpoint = true,
             SaveTokens = true,
        };
        openIdConnectOptions.Scope.Add("offline_access");
        app.UseOpenIdConnectAuthentication(openIdConnectOptions);
