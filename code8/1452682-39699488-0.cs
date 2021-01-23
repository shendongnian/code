        public class SessionHandler : ActionFilterAttribute
        {
            private ApplicationUserManager _userManager;
            private IAuthenticationManager AuthenticationManager
            {
                get
                {
                    return HttpContext.Current.GetOwinContext().Authentication;
                }
            }
            public ApplicationUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }
            public IIdentity UserIdentity
            {
                get { return System.Web.HttpContext.Current.User.Identity; }
            }
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
    
                if (!string.IsNullOrWhiteSpace(UserIdentity.GetUserId()))
                {
                    if (System.Web.HttpContext.Current.Session["Username"] == null)
                    {
                        AuthenticationManager.SignOut();
                        filterContext.Result = new RedirectToRouteResult(
                                      new RouteValueDictionary
                                      {
                                           { "action", "Index" },
                                           { "controller", "Home" }
                                      });
                    }
                }
            }
        }
