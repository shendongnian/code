    public class AuthFilter : AuthorizeFilter
    {
        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAsyncAuthorizationFilter && item != this || item is IAllowAnonymousFilter))
            {
                return Task.FromResult(0);
            }
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return Task.FromResult(0);
            }
    
            return base.OnAuthorizationAsync(context);
        }
    }
