    public class InterceptValueAttribute : ActionFilterAttribute
    {
    
    
    	public override void OnResultExecuted(ResultExecutedContext filterContext)
    	{
    
    		var result = filterContext.Result as ContentResult;
    		
    	    var data = result.Content;
          //use data as required
    
    	}
    
    }
