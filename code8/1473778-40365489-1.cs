    public async Task<IActionResult> GetNestAuthCode()
    {
        // HttpClient setup...
        var response = await client.PostAsJsonAsync("oauth2/access_token", new
        {
            code = "MYPING",
            client_id = "My-Client-ID",
            client_secret = "MySecretString",
            grant_type = "authorization_code"
        });
        // Or check instead with IsSuccessStatusCode
        response.EnsureSuccessStatusCode(); 
        // ReadAsStringAsync() is just an example here
        var content = await response.Content.ReadAsStringAsync(); 
        return Content(content);
    }
