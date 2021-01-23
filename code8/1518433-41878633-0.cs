    public void RegisterUser(string emailAddress)
    {
        var user = new User
        {
            UserName = emailAddress,
            ...
        };
    
        // Give the User a well-known ID, so that we don't have to mess with indexes later.
        user.Id = "Users/" + emailAddress;
        
        ravenSession.Store(user);
    }
