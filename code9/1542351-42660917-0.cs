    public class MyExceptionFilterAttribute : ExceptionFilterAttribute  
        public override void OnException(HttpActionExecutedContext httpActionExecutedContext) {
            // Get expected return type here
            var expectedReturnType = httpActionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
            
        }
    }
