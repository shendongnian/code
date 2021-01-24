    var user = _users.Include(u => u.Role).SingleOrDefault(u => u.UserId == id);
    var userRoleQuery = db.Entry(user).Reference(u => u.Role).Query();
    if (user.Role is ManagerUserRole)
    	userRoleQuery.OfType<ManagerUserRole>().Include(r => r.Groups).Load();
    else if (user.Role is PersonUserRole)
    	userRoleQuery.OfType<PersonUserRole>().Include(r => r.Group).Load();
    return user;
