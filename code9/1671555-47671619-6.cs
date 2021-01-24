    public class AppServiceAuthenticationOptions : AuthenticationSchemeOptions
    {
        public AppServiceAuthenticationOptions()
        {
        }
    }
    
    internal class AppServiceAuthenticationHandler : AuthenticationHandler<AppServiceAuthenticationOptions>
    {
        public AppServiceAuthenticationHandler(
            IOptionsMonitor<AppServiceAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return Task.FromResult(FetchAuthDetailsFromHeaders());
        }
        private AuthenticateResult FetchAuthDetailsFromHeaders()
        {
            Logger.LogInformation("starting authentication handler for app service authentication");
            if (Context.User == null || Context.User.Identity == null || Context.User.Identity.IsAuthenticated == false)
            {
                Logger.LogDebug("identity not found, attempting to fetch from the request headers");
                if (Context.Request.Headers.ContainsKey("X-MS-CLIENT-PRINCIPAL-ID"))
                {
                    var headerId = Context.Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"][0];
                    var headerName = Context.Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"][0];
                    var claims = new Claim[] {
                        new Claim("http://schemas.microsoft.com/identity/claims/objectidentifier", headerId),
                        new Claim("name", headerName)
                    };
                    Logger.LogDebug($"Populating claims with id: {headerId} | name: {headerName}");
                    var identity = new GenericIdentity(headerName);
                    identity.AddClaims(claims);
                    var principal = new GenericPrincipal(identity, null);
                    var ticket = new AuthenticationTicket(principal,
                        new AuthenticationProperties(),
                        Scheme.Name);
                    Context.User = principal;
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Could not found the X-MS-CLIENT-PRINCIPAL-ID key in the headers");
                }
            }
            Logger.LogInformation("identity already set, skipping middleware");
            return AuthenticateResult.NoResult();
        }
    }
