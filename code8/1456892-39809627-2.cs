    public class AwesomeAuthenticationMiddleware : AuthenticationMiddleware<AwesomeAuthenticationOptions>
    {
        public AwesomeAuthenticationMiddleware(RequestDelegate next, 
            IOptions<AwesomeAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder) : base(next, options, loggerFactory, urlEncoder) {
    
        }
    
        protected override AuthenticationHandler<AwesomeAuthenticationOptions> CreateHandler()
        {
            return new AwesomeAuthentication();
        }
    }
