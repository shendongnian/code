    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "_system_authentication_cookie";                    
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.Cookie.HttpOnly = true;
                    
                    options.LoginPath = "/Login/Index/";
                    options.LogoutPath = "/Login/Logout/";
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });
