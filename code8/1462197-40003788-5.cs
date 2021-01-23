        public void CreateUserRoleAccess(string name, int type, string id)
        {
            //Insert role (run only once)
            using (var context = new ApplicationDbContext())
            {
                var role = new ApplicationRole { Id = id, Name = "Role1" };
                var user = context.Users.FirstOrDefault<ApplicationUser>();
                //user.Roles.Add(role);
                role.Users.Add(new IdentityUserRole { RoleId = role.Id, UserId = user.Id });
                context.Roles.Add(role);
                context.SaveChanges();
            }
            using (var context = new ApplicationDbContext())
            {
                var userRoleAccess = new UserRoleAccess();
                //userRoleAccess.ApplicationRole = new ApplicationRole { Id = id };
                userRoleAccess.ApplicationRole = context.Roles.Find(id) as ApplicationRole;
                //Is this a userId or a roleId? Does not seem OK to assign id param here
                userRoleAccess.UserRoleId = id;
                userRoleAccess.IsActive = true;
                userRoleAccess.UserRoleAccessType = type;
                userRoleAccess.Name = name;
                context.UserRoleAccesses.Add(userRoleAccess);
                context.SaveChanges();
            }
        }
