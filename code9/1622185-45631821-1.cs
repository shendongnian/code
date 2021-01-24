    var result = await httpContext.AuthenticateAsync();
    result.Properties.StoreTokens(new List<AuthenticationToken>
    {
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.AccessToken,
            Value = accessToken
        },
        new AuthenticationToken
        {
            Name = OpenIdConnectParameterNames.RefreshToken,
            Value = refreshToken
        }
    });
    
    await httpContext.SignInAsync(result.Principal, result.Properties);
