    public async Task<bool> Login(string username, string password)
    {
       var connectionEx = new ConnectionException();
        try
        {
           ...
        }
        catch (Exception ex)
        {
            throw connectionEx;
        }
        ...
    }
