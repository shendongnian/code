    using (var context = new ApplicationDbContext())
    {
        var result = Roles.GetUsersInRole("prospect")
                          .Select(name => context.Users.FirstOrDefault(user => user.UserName == name))
                          .Where(user => user != null);
    }
