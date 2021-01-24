	public void Configuration(IAppBuilder app)
    {
		app.MapSignalR();//Configure it first  
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Home/Index")
        });
    }
