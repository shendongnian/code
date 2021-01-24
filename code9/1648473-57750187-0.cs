                services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    ...    
                }).AddEntityFrameworkStores<SqliteDbContext>().AddDefaultTokenProviders();
    
    
                // Need to be called after services.AddIdentity not before (it was my mistake)
                services.AddAuthentication(options =>
                {                    
                    // Here is what makes [Authorize] using the JWT instead of Account/Login redirection
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    ...
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ...
                    };
                });
