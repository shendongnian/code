    public class CustomAuthorize : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
                else
                {
                    var rolesArray = Roles.Split(',');
                    var isAllowed = rolesArray.Any(role => filterContext.HttpContext.User.IsInRole(role));
                    if (!isAllowed)
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "AccessDenied" }));
                }
            }
        }
