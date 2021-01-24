    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
	   // ...
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = context =>
            {
                if(shouldIgnoreRequest(context)) // How to ignore Authentication Validations for static files in ASP.NET Identity
                {
                    return Task.FromResult(0);
                }
                return container.GetInstance<IApplicationUserManager>().OnValidateIdentity().Invoke(context);
            }
        },
		// ...
    });
