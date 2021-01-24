    public async Task<bool> Login(string url,string userName, string password)
    {
        try
        {
            var response = await GetLoginData(url, userName, password);
            if(response.UserInfo.UserId > 0){
                IsAuthenticated = true;
            }
            return IsAuthenticated;
        }
        catch (ArgumentException argex)
        {
            ErrorMessage = argex.Message;
            IsAuthenticated = false;
            return IsAuthenticated;
        }
    }
