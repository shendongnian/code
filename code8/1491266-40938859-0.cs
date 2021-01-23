		public void Configure(IApplicationBuilder app) {
		  //...
		  CookieAuthenticationOptions options = new CookieAuthenticationOptions();
		  options.AuthenticationScheme = "MyCookie";
		  options.AutomaticAuthenticate = true;
		  options.CookieName = "MyCookie";
		  app.UseCookieAuthentication(options);
		  //...
		}
