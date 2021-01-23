    public static class UserManagerExtens
    {
        public static IdentityResult AddToRole(this ApplicationUserManager userManager,string userId,string[] roles,string assigner)
        {
            try
            {
                ApplicationUserRole role = null;
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    foreach (var item in roles)
                    {
                        role = new ApplicationUserRole();
                        role.UserId = userId;
                        role.RoleAssigner = assigner;
                        role.RoleId = item;
                        context.AspNetUserRoles.Add(role);
                    }
                    context.SaveChanges();
                }
                return new IdentityResult() { };
            }
            catch (Exception ex)
            {
                return new IdentityResult(ex.Message);
            }
        }
    }
