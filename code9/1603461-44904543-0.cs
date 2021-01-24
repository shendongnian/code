    public static bool IsAdminOrSupervisor(this IPrincipal user, List<string> roles)
    {
        var userRoles = Roles.GetRolesForUser(user.Identity.Name);
    
        return userRoles.Any(u => roles.Contains(u));
    }
