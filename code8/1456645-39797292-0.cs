    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Common", action = "AccessDenied" }));
            }
        }
    }
    
    [CustomAuthorize(Roles = "DOMAIN\\Group")]
    public ActionResult Index()
    {
       ...
    }
