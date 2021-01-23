    var googleOptions = new GoogleOAuth2AuthenticationOptions
    {
        ClientId = Properties.Settings.Default.GoogleClientId,
        ClientSecret = Properties.Settings.Default.GoogleClientSecret,
        Provider = new GoogleOAuth2AuthenticationProvider
        {
            OnAuthenticated = (context) =>
            {
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:google:access_token", context.AccessToken, XmlSchemaString, "Google"));
                return Task.FromResult(0);
            }
        }
    };
    googleOptions.Scope.Add("foo");
    app.UseGoogleAuthentication(googleOptions);
