    public class BadgeEntryHandler : AuthorizationHandler<EnterBuildingRequirement>
    {
        IHttpContextAccessor _httpContextAccessor = null;
        public BadgeEntryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationContext context, 
            EnterBuildingRequirement requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext; // Access context here
            if (context.User.HasClaim(c => c.Type == ClaimTypes.BadgeId &&
                                           c.Issuer == "http://microsoftsecurity"))
            {
                context.Succeed(requirement);
                return Task.FromResult(0);
            }
        }
    }
