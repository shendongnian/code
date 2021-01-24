    services.AddIdentity<ApplicationUser, IdentityRole<int>>(config => {
            config.User.RequireUniqueEmail = true;
        })
    .AddUserStore<UserStore<ApplicationUser, IdentityRole<int>, VisualJobsDbContext, int>>()
    .AddDefaultTokenProviders();
    services.ConfigureApplicationCookie(o => {
        o.LoginPath = new PathString("/Account/Login");
        o.Events = new CookieAuthenticationEvents()
        {
            OnRedirectToLogin = async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/visualjobs") && ctx.Response.StatusCode == 200)
                {
                    ctx.Response.StatusCode = 401;
                }
                else
                {
                    ctx.Response.Redirect(ctx.RedirectUri);
                }
                await Task.Yield();
            }
        };
    });
