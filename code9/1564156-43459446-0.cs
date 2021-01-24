    public class CachingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(ExcludeCacheFilterAttribute), false).Any())
            {
                return;
            }            
  
            //Carry on with the rest of your usual caching code here
        }
    }
