    var twitterOptions = new Microsoft.Owin.Security.Twitter.TwitterAuthenticationOptions
    {
        ConsumerKey = /* Your App's Consumer Key */,
        ConsumerSecret = /* Your App's Consumer Secret */,
        Provider = new Microsoft.Owin.Security.Twitter.TwitterAuthenticationProvider
        {
            OnAuthenticated = (context) =>
            {
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:twitter:access_token", context.AccessToken, XmlSchemaString, "Twitter"));
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:twitter:access_token_secret", context.AccessTokenSecret, XmlSchemaString, "Twitter"));
                return Task.FromResult(0);
            }
        }
    };
    app.UseTwitterAuthentication(twitterOptions);
