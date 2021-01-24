    class AbortUnauthorizedConnections : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.Headers.Add("Content-Length", "0");
                context.HttpContext.Response.Body.Flush();
                context.HttpContext.Abort();
            }
        }
    }
