    // Construct a MyService.UserPermissions object for searching
    var targetPermission = new MyService.UserPermissions("MyPermission");
    var users = UserRepository
        .GetUser()
        .Where(u => u.Permissions.Contains(targetPermission))
        .ToList();
