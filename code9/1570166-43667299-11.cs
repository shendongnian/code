    public static List<string> GetRolesByUserId(string userId)
    {
        var db = new ApplicationDbContext();
      
        var userRoles = from identityUserRole in db.Set<IdentityUserRole>
                        join identityRole in db.Set<IdentityRoles>
                        on identityUserRole.RoleId equals identityRole.RoleId
                        where identityUserRole.UserId == userId
                        select identityRole.Name;
     
        return userRoles.ToList();
    }
