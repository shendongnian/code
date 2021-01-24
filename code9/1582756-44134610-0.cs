    public class Base64FilterAttribute : ActionFilterAttribute
    {
    	public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
    	{
    		if (actionExecutedContext.Exception == null)
    		{
    			var bytes = await actionExecutedContext.Response.Content.ReadAsByteArrayAsync();
    			var base64 = Convert.ToBase64String(bytes);
    			actionExecutedContext.Response.Content = new StringContent(base64); 
    		}
    
    		await base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
    	}
    }
