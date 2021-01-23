    public ActionResult AddRoleToUser()
    {
        var unitOfWork = new UnitOfWork();
        var userService = new UserService(unitOfWork); // This unitOfWork will be passed to RoleService and BaseRepository as well...
        var user = userService.GetById(1);
        var roles = userService.GetSelectedRoles(null);
        user.AddRoles(roles);
        userService.Update(user);
    }
