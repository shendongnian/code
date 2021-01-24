    var auth = await HttpContext.AuthenticateAsync("Cookies");
    auth.Properties.StoreTokens(new List<AuthenticationToken>()
    {
        new AuthenticationToken()
        {
            Name = OpenIdConnectParameterNames.AccessToken,
            Value = newToken.AccessToken
        },
        new AuthenticationToken()
        {
            Name = OpenIdConnectParameterNames.RefreshToken,
            Value = newToken.RefreshToken
        }
    });
    
    await HttpContext.SignInAsync(auth.Principal, auth.Properties);
