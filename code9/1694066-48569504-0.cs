       public class TokenAuthenticationOptions : AuthenticationSchemeOptions
    {
    }
    public class TokenAuthentication : AuthenticationHandler<TokenAuthenticationOptions>
    {
        public const string SchemeName = "TokenAuth";
        public TokenAuthentication(IOptionsMonitor<TokenAuthenticationOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
                : base(options, logger, encoder, clock)
        {
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return Task.Run(() => Authenticate());
        }
        private AuthenticateResult Authenticate()
        {
            string token = Context.Request.Query["token"];
            if (token == null) return AuthenticateResult.Fail("No JWT token provided");
            try
            {
                var principal = LoginControl.Validate(token);
                return AuthenticateResult.Success(new AuthenticationTicket(principal, SchemeName));
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Failed to validate token");
            }
        }
    }
