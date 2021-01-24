    if (DateTimeOffset.UtcNow < TokenLastAccess.AddSeconds(3600))
    {
        // is authorized - no need to Sign In
        return true;
    }
    else
    {
        string token = GetTokenFromVault(TokenTypes.RefreshToken);
        if (!string.IsNullOrWhiteSpace(token))
        {
            StringContent content = new StringContent($"client_secret={ClientSecret}&refresh_token={token}&client_id={ClientID}&grant_type=refresh_token",
                                                      Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await httpClient.PostAsync(TokenEndpoint, content);
            string responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JsonObject tokens = JsonObject.Parse(responseString);
                accessToken = tokens.GetNamedString("access_token");
                foreach (var item in vault.RetrieveAll().Where((x) => x.Resource == TokenTypes.AccessToken.ToString())) vault.Remove(item);
                vault.Add(new PasswordCredential(TokenTypes.AccessToken.ToString(), "MyApp", accessToken));
                TokenLastAccess = DateTimeOffset.UtcNow;
                return true;
            }
        }
    }
