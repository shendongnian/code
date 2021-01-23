    config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
    {
        OnRedirectToLogin = ctx =>
        {
            if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
            {
                ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                ctx.Response.Redirect(ctx.RedirectUri); 
            }
                return Task.FromResult(0); 
       } 
    };
