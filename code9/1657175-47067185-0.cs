      public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
            var appId = ConfigurationCache.GetConfigurationString(TOS_Configuration.KEY_SSO_APPID);
            var authority = ConfigurationCache.GetConfigurationString(TOS_Configuration.KEY_SSO_AUTHORITY);
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
             new OpenIdConnectAuthenticationOptions
             {
                 ClientId = appId,
                 Authority = authority,
                 Notifications = new OpenIdConnectAuthenticationNotifications
                 {
                     AuthorizationCodeReceived = context =>
                     {
                         string username = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.Name).Value; 
                         FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(60), true, "");
                         String encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                         context.Response.Cookies.Append(FormsAuthentication.FormsCookieName, encryptedTicket);
                         return Task.FromResult(0);
                     },
                     AuthenticationFailed = context =>
                     {
                         context.HandleResponse();
                         context.Response.Write(context.Exception.Message);
                         return Task.FromResult(0);
                     }
                 }
             });
            // This makes any middleware defined above this line run before the Authorization rule is applied in web.config
            app.UseStageMarker(PipelineStage.Authenticate);
        }
    }
