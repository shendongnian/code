    private async Task<string> CreatePaymentsTokenAsync()
    {
        var tokenLifeTime = 3600;
        var scopes = new[] { CoinbaseAuthConsts.PaymentScope };
            // Use in-built Identity Server tools to issue JWT
        var token = await _identityServerTools.IssueClientJwtAsync(CoinbaseAuthConsts.AuthorityClientId, 
                tokenLifeTime, scopes, new[] { "YourApiName" });
        return token;
    }
