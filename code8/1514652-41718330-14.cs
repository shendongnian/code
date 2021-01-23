    public static void LoggedAs(UserEntity entity)
    {
        if(sessionUser != null)
            throw new InvalidOperationException("Cannot be logged 2 times with the same session");
    
        sessionUser = entity;
    }
