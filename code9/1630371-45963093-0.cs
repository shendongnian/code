    public static async Task LoginAsync(string username, string password)
    {
        _username = username;
        _password = password;
        Connection.ServiceUserAuthorisationCompleted += UserAuthorisationCompleted;
        await Connection.ServiceUserAuthorisationAsync(_login, _password);
    }
