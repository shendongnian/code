    services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Cookies.ApplicationCookie.AutomaticAuthenticate = true;
            options.Cookies.ApplicationCookie.AutomaticChallenge = true;
            options.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
        })
        .AddEntityFrameworkStores<MehandiContext>()
        .AddDefaultTokenProviders();
