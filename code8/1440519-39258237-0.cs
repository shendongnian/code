    public class PermissionFilterProxy : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // create and wire the actual filter
                // so in this way its lifetime is handled by us
                PermissionFilter permissionFilter = new PermissionFilter();
                permissionFilter.OnActionExecuting(filterContext);
                base.OnActionExecuting(filterContext);
    
            }
        }
    
