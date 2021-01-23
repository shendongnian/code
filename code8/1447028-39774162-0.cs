    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.Google;
    using Microsoft.Owin.Security.Facebook;
    using Owin;
    using System.Web.Helpers;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.Owin.Security;
    
    namespace ui.web
    {
        public partial class Startup
        {
            public void ConfigureAuth(IAppBuilder app)
            {
    
                /* Local logins */
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/login")
                });
    
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    
                /* Google */
                var googleOptions = new GoogleOAuth2AuthenticationOptions
                {
                    ClientId = "clientid",
                    ClientSecret = "secret",
                };
                googleOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");
                googleOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
                app.UseGoogleAuthentication(googleOptions);
    
                /* Facebook */
                var facebookOptions = new FacebookAuthenticationOptions
                {
                    AppId = "clientid",
                    AppSecret = "secret",
                    BackchannelHttpHandler = new FacebookBackChannelHandler(),
                    UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location",
                };
    
                facebookOptions.Scope.Add("email");
                app.UseFacebookAuthentication(facebookOptions);
                
                AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            }
     }
    }
