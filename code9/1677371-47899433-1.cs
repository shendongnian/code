    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
    	public override void OnException(ExceptionContext context)
    	{
    		var items = context.HttpContext.Items;
    		if (items.ContainsKey("Tracking"))
    		{
    			Tracking tracking = (Tracking)items["Tracking"];
    			tracking.Exception(context.Exception, true);
    		}
    
    		base.OnException(context);
    	}
    }
    
    public class ApiTrackingAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext context)
    	{
    		var tracking = new Tracking();
    		//...add info to tracking
    
    		context.HttpContext.Items.Add("Tracking", tracking);
    	}
    
    	public override void OnActionExecuted(ActionExecutedContext context)
    	{
    		var items = context.HttpContext.Items;
    		if (items.ContainsKey("Tracking"))
    		{
    			Tracking tracking = (Tracking) items["Tracking"];
    			tracking.Save();
    		}
    	}
    }
