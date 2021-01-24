    public static async Task<string> AuthenticationCallback(string authority, string resource, string scope) {
        var adCredential = new ClientCredential(applicationId, applicationSecret);
        var authenticationContext = new AuthenticationContext(authority, null);
        return (await authenticationContext.AcquireTokenAsync(resource, adCredential)).AccessToken;
    }
    var client = new KeyVaultClient(AuthenticationCallback);
