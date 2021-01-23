    var users = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Users;
    var roles = HttpContext.GetOwinContext().GetUserManager<RoleManager<IdentityRole>>().Roles;
    var usersWithRoles= users.Select(u =>
        new
        {
            UserName = u.UserName,
            Roles = roles.Where(r => u.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.Name)
        })
       .ToList();
    
