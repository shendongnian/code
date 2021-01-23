    app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
        {
            AuthenticationType = "ApplicationCookie",
            LoginPath = new PathString("/Main/LogIn"),
            Provider = new CookieAuthenticationProvider(), 
            ExpireTimeSpan = TimeSpan.FromDays(5),
            SlidingExpiration = true          
        }); 
