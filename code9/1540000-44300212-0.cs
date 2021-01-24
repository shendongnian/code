    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
    	AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    	LoginPath = new PathString("/account/login"),
    	Provider = new CookieAuthenticationProvider
    	{
    		OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
    			validateInterval: TimeSpan.FromMinutes(30),
    			regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
    		OnApplyRedirect = ctx =>
    		{
    			if (ctx.Request.Path.StartsWithSegments(new PathString("/admin")))
    				ctx.Response.Redirect("/admin/account/login?ReturnUrl=" + HttpUtility.UrlEncode(ctx.Request.Path.ToString()));
    			else
    				ctx.Response.Redirect(ctx.RedirectUri);
    		}
    	},
    });
