    public class ModelStateValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {    
            var modelState = context.ModelState;
    
            if (!modelState.IsValid)
                context.Result = new ContentResult()
                {
                    Content = "Modelstate not valid",
                    StatusCode = 400
                };
            base.OnActionExecuting(context);
        }
    }
