    services.AddIdentity<User, Role>(identityOptions =>
                {
                 // ...
                }).AddUserStore<ApplicationUserStore>()
                  .AddUserManager<ApplicationUserManager>()
                  .AddRoleStore<ApplicationRoleStore>()
                  .AddRoleManager<ApplicationRoleManager>()
                  .AddSignInManager<ApplicationSignInManager>()
                  // You **cannot** use .AddEntityFrameworkStores() when you customize everything
                  //.AddEntityFrameworkStores<ApplicationDbContext, int>()
                  .AddDefaultTokenProviders();
