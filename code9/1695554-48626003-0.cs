    public class MyUnhandledExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {        
        public void OnException(ExceptionContext context)
        {           
            context.Result = new BadRequestObjectResult(context.Exception.Message);
        }
    }
