    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = actionContext.ActionArguments["id"];
        }
    }
