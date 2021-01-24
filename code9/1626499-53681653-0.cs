    services.ConfigureApplicationCookie(options => {
                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        var requestPath = ctx.Request.Path;
                        if (requestPath.Value == "/Home/About")
                        {
                            ctx.Response.Redirect("/Home/UserLogin");
                        }
                        else if (requestPath.Value == "/Home/Contact")
                        {
                            ctx.Response.Redirect("/Home/AdminLogin");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
