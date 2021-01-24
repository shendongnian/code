    private List<User> users;
    
    internal bool DoesUsernameExist(string username)
    {
        return (this.users.Where(x => x.Username == username).Count() > 0);
    }
    
