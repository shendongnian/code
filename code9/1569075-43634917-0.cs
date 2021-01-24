            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                //Creating Admin role  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);
            }
            if (!Roles.IsUserInRole(#yourUserId, "Administrator")) {
                Roles.AddUserToRole(#yourUserId, "Administrator");
            }
