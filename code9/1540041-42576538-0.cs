    public class ParamCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var args = actionContext.ActionArguments;
            if (args.Any(arg => arg.Value == null))
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Null params");
            else
                base.OnActionExecuting(actionContext);
        }
    }
