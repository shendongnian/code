            public void ConfigureAuth(IAppBuilder app)
            {
                app.CreatePerOwinContext(ApplicationDbContext.Create);
                app.CreatePerOwinContext<ApplicationUserManager>
                 (ApplicationUserManager.Create);
                app.CreatePerOwinContext<ApplicationSignInManager>
                  (ApplicationSignInManager.Create);
    
              
                // Configure the sign in cookie
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    CookieName = "TestService",
                    LoginPath = new PathString("/Account/Login"),
                    SlidingExpiration = true,
                    ExpireTimeSpan = TimeSpan.FromMinutes(20000),
                    Provider = new CookieAuthenticationProvider()
                });
            }
