	app.UseCookieAuthentication(new CookieAuthenticationOptions
	{
	    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
	    LoginPath = new PathString("/Account/Login"),
	    Provider = new CookieAuthenticationProvider
	    {
	        // Enables the application to validate the security stamp when the user logs in.
	        // This is a security feature which is used when you change a password or add an external login to your account.  
	        OnValidateIdentity = validate
	        
	    }
	});  
