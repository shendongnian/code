	public class SampleFilter : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Result is ObjectResult)
			{
				var objResult = (ObjectResult)context.Result;
            }
        }
		public void OnActionExecuting(ActionExecutingContext context)
		{
		}
    }
