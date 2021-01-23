    public class AuthorizeClaimFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _claimValue;
        public AuthorizeClaimFilter(string claimValue)
        {
            _claimValue = claimValue;
        }
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {            
            var p = actionContext.RequestContext.Principal as ClaimsPrincipal;
            if(!p.HasClaim("process", _claimValue))
                HandleUnauthorizedRequest(actionContext);
            await Task.FromResult(0);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
