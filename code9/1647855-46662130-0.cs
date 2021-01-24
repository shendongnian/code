    /// <summary>
    /// Acquires security token from the authority.
    /// </summary>
    /// <param name="ctx">Authentication context instance</param>
    /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
    /// <param name="clientCredential">The client credential to use for token acquisition.</param>
    /// <returns>It contains Access Token and the Access Token's expiration time. Refresh Token property will be null for this overload.</returns>
    public static async Task<AuthenticationResult> AcquireTokenAsync(this AuthenticationContext ctx,
        string resource, ClientCredential clientCredential)
    {
        return await ctx.AcquireTokenForClientCommonAsync(resource, new ClientKey(clientCredential))
            .ConfigureAwait(false);
    }
