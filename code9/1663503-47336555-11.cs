    public class TokenCodeAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string DefaultSchemeName = "TokenAuthScheme";
        public TokenCodeAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticateResult result = await this.Context.AuthenticateAsync();
            if (result.Succeeded)
            {
                //User has supplied details
                return AuthenticateResult.Success(result.Ticket);
            }
            else if (Context.Request.Query["token"] == "123abc")   //TODO: Change hard-coded token
            {
                //User has supplied token
                string username = "Test";    //Get/set username here
                var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, username, ClaimValueTypes.String, Options.ClaimsIssuer),
                        new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, Options.ClaimsIssuer)
                    };
                ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
                AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("Unauthorized");
        }
    }
