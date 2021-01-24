    class AbortUnauthorizedConnections : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                // by setting this we make sure the pipe-line will get short-circuited.
                context.Result = new AbortUnauthorizedConnectionResult();
            }
        }
    }
