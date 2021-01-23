        public class OnlyDebugModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
    #if DEBUG
            //Ok
    #else
            context.Result = new ForbidResult();
            return;
    #endif
        }
    }
