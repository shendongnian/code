    services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(15);
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
    });
