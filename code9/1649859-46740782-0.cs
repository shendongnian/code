    public class ForceLoginActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Check if authenticated
            if (filterContext.HttpContext.User.Identity.IsAuthenticated && !filterContext.HttpContext.Request.RawUrl.Equals("/Account/ChangePassword") && !filterContext.HttpContext.Request.RawUrl.Equals("/Account/LogOff"))
            {
                //Get user Data
                MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                if (currentUser.GetPassword().Equals("password"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                                           new RouteValueDictionary
                                            {
                                            { "controller", "Account" },
                                            { "action", "ChangePassword" }
                                            });
                }
            }
        }
    }
