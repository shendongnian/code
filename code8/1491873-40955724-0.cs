    public class IsRequestFromSameDomainAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer != null )
            {
                //do something
            }
            else 
            {
                //do something
            }
        }
    }
