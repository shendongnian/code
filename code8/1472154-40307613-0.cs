    [assembly: OwinStartup(typeof(YourApplicationName.Startup))]
    namespace YourApplicationName
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login")
                });
            }
        }
    }
