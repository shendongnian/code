    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
    		
    		var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
    		var provider = new CookieAuthenticationProvider();
    		var originalHandler = provider.OnApplyRedirect;
    		provider.OnApplyRedirect = context =>
    		{
    			var routeValues = new RouteValueDictionary();
    			var uri = new Uri(context.RedirectUri);
    			var returnUrl = HttpUtility.ParseQueryString(uri.Query)[context.Options.ReturnUrlParameter];
    			routeValues.Add(context.Options.ReturnUrlParameter, returnUrl);
    			context.RedirectUri = url.Action("Login", "Account", routeValues);
    			originalHandler.Invoke(context);
    		};
    		provider.OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager));
    		
    		
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = provider,
    			SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(30)
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    
            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
