    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        //Called when access is denied
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Login" })
            );
        }
        //Core authentication, called before each action
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userId = httpContext.Session["UserId"];
            return userId != null;
        }
    }
