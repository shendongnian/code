    public async Task GetUsersInRole()
    {
        ApplicationDbContext context = new ApplicationDbContext();
        var roles = context.Roles.Where(r => r.Name == "Professor");
        if (roles.Any())
        {
            var users = await UserManager.Users.ToListAsync();
            var result = (from c in users
                           where c.Roles.Any(r => r.RoleId == roles.First().Id)
                           select c);
        }
    }
