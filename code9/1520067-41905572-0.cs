    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    
    //This line tells Owin which method to call
    [assembly: OwinStartup(typeof(TokenBasedAuthenticationSample.IdentityConfig))]
    namespace TokenBasedAuthenticationSample
    {
        public class IdentityConfig
        {
            public void Configuration(IAppBuilder app)
            {
                //Here we add cookie authentication middleware to the pipeline 
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/login"),
                });
            }
        }
    }
