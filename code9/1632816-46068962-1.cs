    public class YourFilter : ActionFilterAttribute, IActionFilter
    {
    	//The action excecuted on each page
    	void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		// Check if the Attribute "AnotherFilter" is used
    		if (filterContext.ActionDescriptor.IsDefined(typeof(AnotherFilter), true) || filterContext.Controller.GetType().IsDefined(typeof(AnotherFilter), true))
    		{
    			// things to do if the filter is used
    			
    		}
    	}
    }
