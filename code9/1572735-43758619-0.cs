    public class MyCustomFilter : IAuthenticationFilter
    {
    	public bool AllowMultiple { get; }
    
    	public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    	{
    		string actionName = context.ActionContext.ActionDescriptor.ActionName;
    		string controllerName = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
    	}
    }
