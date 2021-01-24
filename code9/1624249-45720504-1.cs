    ApplicationDbContext context = new ApplicationDbContext();
    var roles = context.Roles.Where(r => r.Name == "Professor");
    if (roles.Any())
    {
        var result = from c in context.Users
                     where c.Roles.Any(r => r.RoleId == roles.First().Id)
                     select c;
    }
