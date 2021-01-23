    public static class OpenIdConnectAuthenticationPatchedMiddlewareExtension
        {
            public static Owin.IAppBuilder UseOpenIdConnectAuthenticationPatched(this Owin.IAppBuilder app, Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationOptions openIdConnectOptions)
            {
                if (app == null)
                {
                    throw new System.ArgumentNullException("app");
                }
                if (openIdConnectOptions == null)
                {
                    throw new System.ArgumentNullException("openIdConnectOptions");
                }
                System.Type type = typeof(OpenIdConnectAuthenticationPatchedMiddleware);
                object[] objArray = new object[] { app, openIdConnectOptions };
                return app.Use(type, objArray);
            }
        }
    
        /// <summary>
        /// Patched to fix the issue with too many nonce cookies described here: https://github.com/IdentityServer/IdentityServer3/issues/1124
        /// Deletes all nonce cookies that weren't the current one
        /// </summary>
        public class OpenIdConnectAuthenticationPatchedMiddleware  : OpenIdConnectAuthenticationMiddleware
        {
            private readonly Microsoft.Owin.Logging.ILogger _logger;
    
            public OpenIdConnectAuthenticationPatchedMiddleware(Microsoft.Owin.OwinMiddleware next, Owin.IAppBuilder app, Microsoft.Owin.Security.OpenIdConnect.OpenIdConnectAuthenticationOptions options) 
                    : base(next, app, options)
            {
                this._logger = Microsoft.Owin.Logging.AppBuilderLoggerExtensions.CreateLogger<OpenIdConnectAuthenticationPatchedMiddleware>(app);
            }
    
            protected override Microsoft.Owin.Security.Infrastructure.AuthenticationHandler<OpenIdConnectAuthenticationOptions> CreateHandler()
            {
                return new SawtoothOpenIdConnectAuthenticationHandler(_logger);
            }
    
            public class SawtoothOpenIdConnectAuthenticationHandler : OpenIdConnectAuthenticationHandler
            {
                public SawtoothOpenIdConnectAuthenticationHandler(Microsoft.Owin.Logging.ILogger logger)
                    : base(logger) { }
    
                protected override void RememberNonce(OpenIdConnectMessage message, string nonce)
                {
                    var oldNonces = Request.Cookies.Where(kvp => kvp.Key.StartsWith(OpenIdConnectAuthenticationDefaults.CookiePrefix + "nonce"));
                    if (oldNonces.Any())
                    {
                        Microsoft.Owin.CookieOptions cookieOptions = new Microsoft.Owin.CookieOptions
                        {
                            HttpOnly = true,
                            Secure = Request.IsSecure
                        };
                        foreach (KeyValuePair<string, string> oldNonce in oldNonces)
                        {
                            Response.Cookies.Delete(oldNonce.Key, cookieOptions);
                        }
                    }
                    base.RememberNonce(message, nonce);
                }
            }
        }
