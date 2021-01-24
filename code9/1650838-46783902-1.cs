    public class CustomAuthorize : AuthorizeAttribute
    {
        private User_MasterEntities db = new User_MasterEntities();
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Restricted" }));//new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }
            string user = HttpContext.Current.User.Identity.Name;
            bool isAdmin = IsAppUser(user);
            return isAdmin;
        }
