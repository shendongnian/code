    public class WebLoginAuthenticationMiddleware : AuthenticationMiddleware<WebLoginAuthenticationOptions>
    {
        public WebLoginAuthenticationMiddleware(OwinMiddleware nextMiddleware,
                                                WebLoginAuthenticationOptions authOptions)
            : base(nextMiddleware, authOptions)
        {
        }
        protected override AuthenticationHandler<WebLoginAuthenticationOptions> CreateHandler()
        {
            return new WebLoginAuthenticationHandler();
        }
    }
