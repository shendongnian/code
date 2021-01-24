    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Exception exception = context.Exception;
            if (exception is AggregateException
                && exception.InnerException != null)
            {
                exception = exception.InnerException;
            }
            // check type and do you stuff ........
            context.Response = new HttpResponseMessage
            {
                Content = this.CreateContent(response),
                StatusCode = HttpStatusCode.BadRequest
            };
            //....
