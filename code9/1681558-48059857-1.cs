    public HttpRequestWrapper TokenizeRequest(User user, string clientid)
    {
        var token = GetToken(user, clientid).Result;
        _request.AddHeader("Authorization", $"Bearer {token.AccessToken}");
        return this;
    }
    
    private async Task<TokenResponse> GetToken(User user, string clientid)
    {
        var client = new TokenClient(Constants.TokenEndpoint, clientid, SecretApi);
    
        return  client.RequestResourceOwnerPasswordAsync
               (user.UserName, user.Password, "WebAPI").Result;
    }
