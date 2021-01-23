    public class Startup
    {
       public void Configuration(IAppBuilder app)
       {
          app.UseCookieAuthentication(new CookieAuthenticationOptions
          {
            AuthenticationType = "ApplicationCookie",
            LoginPath = new PathString("/Account/Login")
          });
       }
    }
