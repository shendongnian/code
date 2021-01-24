    public partial class Startup
        {    
            public void Configuration(IAppBuilder app)
            {
    
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login")
                });
    
    
                LogProvider.SetCurrentLogProvider(new HangfireLogProvider());
    
                GlobalConfiguration.Configuration.UseSqlServerStorage("HangfirePersistence");
    
                app.UseHangfireDashboard("/jobs", new DashboardOptions
                {
                    Authorization = new[] { new HangfireAuthFilter() }
                });
    
                app.UseHangfireServer();
    
                ConfigureAuth(app);
            }
        }
    public class HangfireAuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var user = HttpContext.Current.User;
            return user != null && user.IsInRole("Admin") && user.Identity.IsAuthenticated;
        }
    }
