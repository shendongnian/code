    private async Task AddTokensToCookie(ApplicationUser user, string password)
    {
        // Retrieve access_token & refresh_token
        var disco = await DiscoveryClient.GetAsync(Environment.GetEnvironmentVariable("AUTHORITY_SERVER") ?? "http://localhost:5000");
        if (disco.IsError)
        {
            _logger.LogError(disco.Error);
            throw disco.Exception;
        }
        var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
        var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(user.Email, password, "offline_access api1");
        var tokens = new List<AuthenticationToken>
        {
            new AuthenticationToken {Name = OpenIdConnectParameterNames.AccessToken, Value = tokenResponse.AccessToken},
            new AuthenticationToken {Name = OpenIdConnectParameterNames.RefreshToken, Value = tokenResponse.RefreshToken}
        };
        var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn);
        tokens.Add(new AuthenticationToken
        {
            Name = "expires_at",
            Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
        });
        // Store tokens in cookie
        var prop = new AuthenticationProperties();
        prop.StoreTokens(tokens);
        prop.IsPersistent = true; // Remember me
        await _signInManager.SignInAsync(user, prop);
    }
