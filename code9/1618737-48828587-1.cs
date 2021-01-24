    internal class CustomAuthenticationHandler : 
        AuthenticationHandler<CustomAuthenticationOptions>
    {
        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : 
            base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                // Your auth code here
                // Followed by something like this:
                    return AuthenticateResult.Success(
                        new AuthenticationTicket(
                            new ClaimsPrincipal(
                                new ClaimsIdentity(
                                    new List<Claim>() { new Claim(ClaimTypes.Sid, Id.ToString()) },
                                    Scheme.Name)),
                            Scheme.Name));
            }        
            catch
            {
                return AuthenticateResult.Fail("Error message.");
            }
        }
    }
