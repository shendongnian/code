    public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
        // store custom services here...
    }
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // build the claims and put them in "Context"
        return AuthenticateResult.NoResult();
    }
`
