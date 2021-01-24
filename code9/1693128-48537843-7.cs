    public class MyAuthorize : AuthorizeAttribute
    {
        private bool noPermission = false;
        public string Permissions { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
                return false;
            var permissionArrs = Permissions.Trim().Split('|');
            if (permissionArrs.ToList().Exists(p=>httpContext.User.IsInRole(p)))
            {
                return true;
            }
            else
            {
                noPermission = true;
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (noPermission)
                filterContext.Result = new ContentResult() { Content = "You don't have rights to take actions" };
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
