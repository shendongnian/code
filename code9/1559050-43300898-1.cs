    public partial class Startup
    {
        public OAuthBearerAuthenticationOptions oabao;
        public void Configuration(IAppBuilder app)
        {
            
            // repeated code omitted
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            oabao = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(oabao);
            // insert actual web API and we're off!
            app.UseWebApi(config);
        }
    }
