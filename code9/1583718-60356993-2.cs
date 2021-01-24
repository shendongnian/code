    // ApiKeyAuthenticationOptions.cs
    // ... 
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }
    
    // ApiKeyAuthenticationHandler.cs
    // ...
    internal class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private const string ProblemDetailsContentType = "application/problem+json";
        public const string ApiKeyHeaderName = "X-Api-Key";
        private readonly IApiKeyService _apiKeyService;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyService apiKeyService,
            ProblemDetailsFactory problemDetailsFactory) : base(options, logger, encoder, clock)
        {
            _apiKeyService = apiKeyService ?? throw new ArgumentNullException(nameof(apiKeyService));
            _problemDetailsFactory = problemDetailsFactory ?? throw new ArgumentNullException(nameof(problemDetailsFactory));
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValues))
            {
                return AuthenticateResult.NoResult();
            }
            Guid.TryParse(apiKeyHeaderValues.FirstOrDefault(), out var apiKey);
            if (apiKeyHeaderValues.Count == 0 || apiKey == Guid.Empty)
            {
                return AuthenticateResult.NoResult();
            }
            var existingApiKey = await _apiKeyService.FindApiKeyAsync(apiKey);
            if (existingApiKey == null)
            {
                return AuthenticateResult.Fail("Invalid API Key provided.");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, existingApiKey.Owner)
            };
            var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
            var identities = new List<ClaimsIdentity> { identity };
            var principal = new ClaimsPrincipal(identities);
            var ticket = new AuthenticationTicket(principal, Options.Scheme);
            return AuthenticateResult.Success(ticket);
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = _problemDetailsFactory.CreateProblemDetails(Request.HttpContext, StatusCodes.Status401Unauthorized, nameof(HttpStatusCode.Unauthorized),
                detail: "Bad API key.");
            await Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = StatusCodes.Status403Forbidden;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = _problemDetailsFactory.CreateProblemDetails(Request.HttpContext, StatusCodes.Status403Forbidden, nameof(HttpStatusCode.Forbidden),
                detail: "This API Key cannot access this resource.");
            await Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
