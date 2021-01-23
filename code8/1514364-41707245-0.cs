        public class ClientAuthorize : AuthorizeAttribute
    {
        public new String Role { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return DoAUthorizationAndReturnBool(Role);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                if(Role=="Admin")
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "admin", action = "login" }));
                else
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "user", action = "login" }));
            }
        }
    
    }
