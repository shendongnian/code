    public static async Task<string> GetToken(string authority, string resource, string scope)
    {
        var assertionCert = new ClientAssertionCertificate(clientId, certificate);
        var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
        var result = await context.AcquireTokenAsync(resource, assertionCert).ConfigureAwait(false);
        return result.AccessToken;
    }
