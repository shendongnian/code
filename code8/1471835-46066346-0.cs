    public class ViewIfAcceptHtmlAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Headers["Accept"].ToString().Contains("text/html"))
            {
                var originalResult = context.Result as ObjectResult;
                var controller = context.Controller as Controller;
                if(originalResult != null && controller != null)
                {
                    var model = originalResult.Value;
                    var newResult = controller.View(model);
                    newResult.StatusCode = originalResult.StatusCode;
                    context.Result = newResult;
                }
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
