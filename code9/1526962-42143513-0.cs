    public async Task<RedirectResult> Callback(string jwtResponse)
    {
        var client = Request.GetStormpathClient();
        var app = await client.GetApplicationAsync(appUrl);
        var exchangeRequest = new StormpathTokenGrantRequest
        {
            Token = jwtResponse
        });
    
        var grantResponse = await application.ExecuteOauthRequestAsync(exchangeRequest);
        // Return grantResponse.AccessTokenString in a secure HTTPOnly cookie, or as a JSON response
    }
