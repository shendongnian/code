    public class DbAuthorize : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var isAuthorized = base.IsAuthorized(actionContext);
            var user = actionContext.ControllerContext.RequestContext.Principal.Identity;
            if (user == null)
                return false;
            return isAuthorized && UserManager.IsInRole(user.Name, this.Roles);
        }
    }
