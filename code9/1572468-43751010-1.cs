        protected override void Seed(ApplicationDbContext context)
         {
    //initialized Role
           context.Roles.AddOrUpdate(r => r.Name,
                        new IdentityRole { Name = "SuperAdmin" },
                        new IdentityRole { Name = "Admin" },  
                        new IdentityRole { Name = "User" }
                        );
        
        //initialized Admin user
        if (!context.Users.Any(u => u.UserName == "ashiquzzaman@outlook.com"))
                    {
                        var store = new UserStore<ApplicationUser>(context);
                        var manager = new UserManager<ApplicationUser>(store);
                        var user = new ApplicationUser
                        {                 
                            UserName = "ashiquzzaman@outlook.com",
                            Email = "ashiquzzaman@outlook.com",
                            PhoneNumber = "+8801717252600",                  
                            //.......
                        };
                        manager.Create(user, "aSHIQ!109");
                        manager.AddToRole(user.Id, "Admin");
                    }
          }
