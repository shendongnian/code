    private bool PasswordIsValid(string userName, string password)
    {
        string expectedPassword = _users[userName];
        if (password == null || expectedPassword != password)
            return false;
        return true;
    }
