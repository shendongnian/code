    public IQueryable<ApplicationUser> QueriableUsersList()
    {
        return _context.Users.OrderBy(u => u.UserName)           
            .Include(u => u.Accounts.Select(a => a.Broker))
            .Include(u => u.Roles);
    }
