    public async Task<bool> Login(string username, string password)
    {
        //TODO: Do parameter check for username and password
        try
        {
            var response = await GetAsync(new Uri(Constants.loginEndpoint + username + "/" + password + "/"));
            if (response.IsSuccessStatusCode)
            {
                // Process the positive response here
                
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new ConnectionException();
        }
        return false;
    }
