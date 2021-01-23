    public string GivenUsernameGetUserId(string userName)
    {
       // Look ma, no query needed.
       return "Users/" + userName;
       // Or, need to return the User itself? You can use .Load, which will never be stale.
       // return ravenSession.Load<User>("Users/" + userName);
    }
