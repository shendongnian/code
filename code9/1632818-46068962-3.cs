    public class OneFilter : ActionFilterAttribute, IActionFilter
    {
    	void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		// Check if the Attribute "AnotherFilter" is used
    		if (filterContext.ActionDescriptor.IsDefined(typeof(AnotherFilter), true) || filterContext.Controller.GetType().IsDefined(typeof(AnotherFilter), true))
    		{
    			// things to do if the filter is used
    			
    		}
    	}
    }
    public class AnotherFilter : ActionFilterAttribute, IActionFilter
    {
       // filter things
    }
