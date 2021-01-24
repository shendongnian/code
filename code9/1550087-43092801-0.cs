    public class WebApiExceptionHandler : ExceptionHandler {
    
        public override void Handle(ExceptionHandlerContext context) {
            var innerException = context.ExceptionContext.Exception;
            // Ignore HTTP errors
            if (innerException.GetType().IsAssignableFrom(typeof(System.Web.HttpException))) {
                return;
            }
    
            if(innerException is BusinessException) {
                context.Result = BuildErrorResult(exception);
                return;
            }
    
            //...other handler code
        }
    
        IHttpActionResult BuildErrorResult(BusinessException exception) { 
            //... your logic here 
        }
    }
