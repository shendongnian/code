    [AttributeUsage(validOn: AttributeTargets.Method)]
    public class AuthorizeClaimsFilterAttribute : AuthorizationFilterAttribute
    {
        public AuthorizeClaimsFilterAttribute(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public string ClaimType { get; }
        public string ClaimValue { get; }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!(actionContext.RequestContext.Principal is ClaimsPrincipal principal)
                || !principal.HasClaim(x => x.Type == ClaimType && x.Value == ClaimValue))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
