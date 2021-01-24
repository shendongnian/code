                services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {               
                //  Require a confirmed email in order to log in
                config.SignIn.RequireConfirmedEmail = true;
                // Cookie settings
                config.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(10);
                config.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
                config.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
