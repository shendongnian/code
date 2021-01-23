    app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login"),
          
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(40)
            });
