    public class ClientAuthorize : AuthorizeAttribute
    {
        public new String Roles { get; set; }
        public String RequiredRights { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return CustomAuthorizeLogicReturnsBool(Roles, RequiredRights);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //filterContext.Result = new HttpUnauthorizedResult();
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
        }
    
    }
