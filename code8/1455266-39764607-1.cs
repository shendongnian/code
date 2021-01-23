    namespace MyNamespace
    {
        public class IdentityConfig
            {
                public void Configuration(IAppBuilder app)
                {
                    app.CreatePerOwinContext(() => new WeirdMachineContext());
                    app.UseCookieAuthentication(new CookieAuthenticationOptions
                    {
                        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                        LoginPath = new PathString("/Home/Login"),
                    });
                    FormsAuthentication.SetAuthCookie("CookieValue", false);
                }
            }
    }
