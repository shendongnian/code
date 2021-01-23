    public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(
                config => { config.User.RequireUniqueEmail = true;
                    config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                    config.Cookies.ApplicationCookie.AuthenticationScheme = "Cookie";
                    config.Cookies.ApplicationCookie.AutomaticAuthenticate = false;
                    config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
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
                }).AddEntityFrameworkStores<VisualJobsDbContext, int>()
              .AddDefaultTokenProviders();
            services.AddEntityFramework().AddDbContext<VisualJobsDbContext>();
            services.AddScoped<IRecruiterRepository, RecruiterRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            return services;
        }
