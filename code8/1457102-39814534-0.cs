    public class SystemAdminAttribute : AuthorizeAttribute
    {
        private const string SysAdminRole = "System Administrator";
        public SystemAdminFilter()
        {   
            //this defines the role that will be used to authorize the user:
            this.Roles = SysAdminRole;
        }  
        //if user is not authorized redirect to "Home/NoPermissions" page
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                   RouteValueDictionary(new { controller = "Home", action = "NoPermissions" }));
             }
         }           
    }
