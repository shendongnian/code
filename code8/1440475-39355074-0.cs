    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
    
            /*Other external login options*/
    
             var FacebookOptions = new FacebookAuthenticationOptions()
                    {
                        AppId = "My App Id",
                        AppSecret = "My App Secret",
                        SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                        BackchannelHttpHandler = new FacebookBackChannelHandler(),
                        Scope = { "email" },
                        UserInformationEndpoint = "https://graph.facebook.com/v2.7/me?fields=id,name,email"
                    };
        }
    }
