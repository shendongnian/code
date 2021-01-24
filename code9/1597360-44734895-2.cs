    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        Events = new CookieAuthenticationEvents
        {
            OnRedirectToAccessDenied = RedirectToAccessDenied,
            OnRedirectToLogin = ...
            OnRedirectToLogout = ...
            OnRedirectToReturnUrl = ...
        }
    });
