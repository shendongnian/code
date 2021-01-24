    public bool CheckUserExists(string inputUserId)
    {
        var existingUser = GetUserFromDatabase(inputUserId);
        
        if (existingUser == null)
        {
            return false; // The user doesn't exist
        }
        else
        {
            return true; // The user does exist already
        }
    }
