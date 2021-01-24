            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("SuperUser"))
            {
                roleManager.Create(new IdentityRole("SuperUser"));
                //superuser
                var user = new ApplicationUser
                {
                    UserName = " Name",
                    Email = "Email",
                    Firstname = "Firstname",
                    Lastname = "Lastname"
                };
                var pass = "AwesomePasswordOverHere";
                var chkUser = await userManager.CreateAsync(user, pass);
                //make superuser 
                if (chkUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user.Id, "SuperUser");
                }
            }
