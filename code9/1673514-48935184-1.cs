    public class LogResultFilter : IActionFilter, IResultFilter
    {
    	public void OnResultExecuted(ResultExecutedContext filterContext)
    	{
    
            var responseBody = string.Empty;
            if (filterContext.Result is ViewResultBase)
            {
                responseBody = new JavaScriptSerializer().Serialize(((ViewResultBase)filterContext.Result).ViewData);
            }
            if (filterContext.Result is JsonResult)
            {
                responseBody = new JavaScriptSerializer().Serialize(((JsonResult)filterContext.Result));
            }
    
    		// Continue...	
