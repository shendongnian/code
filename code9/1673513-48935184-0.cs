    public class LogResultFilter : IActionFilter, IResultFilter
    {
    	public void OnResultExecuted(ResultExecutedContext filterContext)
    	{
    
    		var responseBody = new JavaScriptSerializer().Serialize(filterContext.Result);
    
    		// Continue...	
