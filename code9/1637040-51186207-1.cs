    services.AddAuthentication(sharedOptions =>
    {
        sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
      .AddCookie(options =>
      {
          options.Events.OnRedirectToAccessDenied = DontRedirectAjaxOrApiRequestToForbidden;
      })
      .AddOpenIdConnect(options =>
      {
          ...
          options.Events.OnRedirectToIdentityProvider = DontRedirectAjaxRequestToOpenIdProvider;
      });
    /// <summary>
    /// Unauthenticated ajax or API request returns 403 rather than Redirect to forbidden page
    /// </summary>
    private static Task DontRedirectAjaxOrApiRequestToForbidden(RedirectContext<CookieAuthenticationOptions> ctx)
    {
        bool isAjaxRequest = ctx.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
        if (isAjaxRequest || (ctx.Request.Path.StartsWithSegments("/api")))
        {
            ctx.Response.StatusCode = 403;
        }
        else
        {
            ctx.Response.Redirect(ctx.RedirectUri);
        }
        return Task.CompletedTask;
    }
    /// <summary>
    /// Unauthenticated ajax request returns 401 rather than Redirect
    /// </summary>
    private static Task DontRedirectAjaxRequestToOpenIdProvider(RedirectContext redirectContext)
    {
        bool isAjaxRequest = redirectContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
        if (isAjaxRequest)
        {
            redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            redirectContext.HttpContext.Response.Headers["Location"] = CookieAuthenticationDefaults.LoginPath.Value;
            redirectContext.HandleResponse();
        }
        return Task.CompletedTask;
    }
