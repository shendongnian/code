            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Cookies.ApplicationCookie.CookieDomain = ".yourdomain.com";
                options.Cookies.ApplicationCookie.CookieSecure = Microsoft.AspNetCore.Http.CookieSecurePolicy.None;
            })
