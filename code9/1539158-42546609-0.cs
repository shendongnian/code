    new Client
    {
        ClientId = "oauthClient",
        ClientName = "Example Client Credentials Client Application",
        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
        ClientSecrets = new List<Secret> {
            new Secret("superSecretPassword".Sha256())},
        AllowedScopes = new List<string> {"customAPI.read"}
    }
