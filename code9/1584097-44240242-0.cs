    var discoveryResponse = await DiscoveryClient.GetAsync("IdentityServer url");
    if (discoveryResponse.IsError)
    {
        throw new Exception(discoveryResponse.Error);
    }
    
    var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, "ClientId", "ClientSecret");
    // This will request a new access_token and a new refresh token.
    var tokenResponse = await tokenClient.RequestRefreshTokenAsync(await httpContext.Authentication.GetTokenAsync("refresh_token"));
    
    if (tokenResponse.IsError)
    {
        // Handle error.
    }
    
    var oldIdToken = await httpContext.Authentication.GetTokenAsync("id_token");
    var newAccessToken = tokenResult.AccessToken;
    
    var tokens = new List<AuthenticationToken>
    {
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.IdToken,
            Value = oldIdToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.AccessToken,
            Value = newAccessToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.RefreshToken,
            Value = tokenResult.RefreshToken
        }
    };
    
    var expiresAt = DateTime.UtcNow.AddSeconds(tokenResult.ExpiresIn);
    tokens.Add(new AuthenticationToken
    {
        Name = "expires_at",
        Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
    });
    
    // Sign in the user with a new refresh_token and new access_token.
    var info = await httpContext.Authentication.GetAuthenticateInfoAsync("Cookies");
    info.Properties.StoreTokens(tokens);
    await httpContext.Authentication.SignInAsync("Cookies", info.Principal, info.Properties);
