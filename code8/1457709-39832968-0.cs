    public IQueryable<User> GetUsers()
    {
        IQueryable<User> users;
        using (UserContext userContext = new UserContext())
        {
            users = userContext.Users;
            if (users.Any() == false)
            {
                return null;
            }
            else
            {
                return users;
            }
        }
    }
