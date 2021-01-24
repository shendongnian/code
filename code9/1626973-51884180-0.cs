    services.ConfigureApplicationCookie(options => { //this just makes checks against the cookie, so if the user deletes the cookie then ValidateAsync never fires
				// Cookie settings ...
				options.Events.OnRedirectToAccessDenied = CookieValidator.overrideRedirect;
                options.Events.OnValidatePrincipal = CookieValidator.ValidateAsync;
			});
 
