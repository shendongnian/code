                // authentication cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/"; //new Microsoft.AspNetCore.Http.PathString("/");
                    options.AccessDeniedPath = "/"; //new Microsoft.AspNetCore.Http.PathString("/");
                });
            // Add EntityFramework's Identity support.
            services.AddEntityFrameworkSqlServer();
            // Add ApplicationDbContext.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
                );
