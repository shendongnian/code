    namespace YourNamespace
    {
    public class AccessDeniedAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            // Redirect to the login page if necessary
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url);
                return;
            }
            // Redirect to your "access denied" view here
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Account/Denied");
            }
        }
    }
    }
