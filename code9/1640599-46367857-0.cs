    public class JwtAuthentication : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader=actionContext.Request.Headers.Authorization;
            if (authHeader!=null&& !String.IsNullOrWhiteSpace(authHeader.Parameter))
                System.Threading.Thread.CurrentPrincipal = JwtAuthenticationHandler.GetPrincipal(authHeader.Parameter);
            return ClientAuthorize.Authorize(Roles);
        }
    }
