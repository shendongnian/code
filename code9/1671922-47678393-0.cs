    public class SessionTimeoutAttribute: AuthorizeAttribute {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext) {
    
            if (filterContext.HttpContext.User.Identity.IsAuthenticated) {
                base.HandleUnauthorizedRequest(actionContext);
            } else {
               actionContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
    
        }
    }
