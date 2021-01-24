    public class MyExceptionFilterAttribute : ExceptionFilterAttribute 
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Exception is NotImplementedException)
                {
                    context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                }
                // Other checks can be added
            }
        }
