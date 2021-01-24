    public class ValidateModelAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext context)
    	{
    		base.OnActionExecuting(context);
    
    		if (!context.ModelState.IsValid)
    			context.Result = new BadRequestObjectResult(new
    			{
    				message = context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
    			});
    	}
    }
