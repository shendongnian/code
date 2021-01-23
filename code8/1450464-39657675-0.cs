    public partial class Startup
        {
            public void ConfigureAuth(IAppBuilder app)
            {
                app.CreatePerOwinContext(ApplicationDbContext.Create);
                app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
                app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider = new CookieAuthenticationProvider
                    {
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                    }
                });
                ExpireTimeSpan = TimeSpan.FromDays(7);
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
                app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            }
        }
