public class TimestampFilter : IActionFilter, IAsyncActionFilter 
{    
    public void OnActionExecuting(ActionExecutingContext context)    
    {         
        context.ActionDescriptor.RouteValues["timestamp"] = DateTime.Now.ToString();    
    }
    public void OnActionExecuted(ActionExecutedContext context)    
    {         
        var ts = DateTime.Parse(context.ActionDescriptor. RouteValues["timestamp"]).AddHours(1).ToString();        
        context.HttpContext.Response.Headers["X-EXPIRY-TIMESTAMP"] = ts;    
    }
     public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)    
    {        
        this.OnActionExecuting(context);        
        var resultContext = await next();
        this.OnActionExecuted(resultContext);    
    }
 }
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2#implementation
