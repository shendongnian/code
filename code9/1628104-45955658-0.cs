    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
             {                 
                 options.Events.OnRedirectToLogin = context =>
                 {
                     context.Response.Headers["Location"] = context.RedirectUri;
                     context.Response.StatusCode = 401;
                     return Task.CompletedTask;
                 };
             });
