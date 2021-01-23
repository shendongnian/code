        public class BALExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
         {
            base.OnException(actionExecutedContext);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, new { error = actionExecutedContext.Exception.Message });
        }
    }
