    public List<User> GetUsers()
    {
        using (var ctx = new HomstersTestDBEntities())
        {
            var items = ctx.Users.Include(x => x.Roles).ToList();
            return items;
        }
    }
