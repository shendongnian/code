    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public BasicAuthenticationOptions()
        {
        }
    }
    internal class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private const string _Scheme = "MyScheme";
        public BasicAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorizationHeader = Request.Headers["Custom-Auth-Handler"];
            // create a ClaimsPrincipal from your header
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "My Name")
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));
            var ticket = new AuthenticationTicket(claimsPrincipal,
                new AuthenticationProperties { IsPersistent = false },
                Scheme.Name
            );
            
            return AuthenticateResult.Success(ticket);
        }
