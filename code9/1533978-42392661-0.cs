    services.AddIdentity<ApsUser, ApsRole>(option =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApContext, int>()
                .AddDefaultTokenProviders();
 
