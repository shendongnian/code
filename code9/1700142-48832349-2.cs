    public class ValidateModelAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		if (!filterContext.ModelState.IsValid)
    		{
    			filterContext.Result = new BadRequestResult();
    		}
    	}
    }
