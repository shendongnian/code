    i think this helpful and you can get an idea to solve this problem.
    
    
    
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
    
    
    Reference : 
    https://www.codeproject.com/Articles/1163131/IdentityServer-WebAPI-MVC-ASP-NET-Identity-Specflo
