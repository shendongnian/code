    public class GeneralExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
