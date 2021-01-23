    public IEnumerable<User> getUsers(string color, int room)
    {
        IEnumerable<User> users = dbContext.Where(x => x.Room == room && x.Color == color);
        return users;
    }
