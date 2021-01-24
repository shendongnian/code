    public class DenyByControllerActionAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var controller = httpContext.Request.RequestContext.RouteData.GetRequiredString("controller");
            var action = httpContext.Request.RequestContext.RouteData.GetRequiredString("action");
            var denyRole = string.Format("Deny{0}:{1}", controller, action);
            return !httpContext.User.IsInRole(denyRole) && base.AuthorizeCore(httpContext);
        }
    }
