     public class MyExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var t = HandleException(context);
            t.Wait();
        }
        public override async Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
        {
           await HandleException(context);
        }
        private Task HandleException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
            return Task.CompletedTask;
        }
    }
