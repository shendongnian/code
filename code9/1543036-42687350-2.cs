    public static bool loggedIn()
    {
    
        if (gmailAddress == "" || gmailPassword == "")
        {
            return false;
        }
        else
        {
            IsAuthorized = true;
            return true;
        }
    }
