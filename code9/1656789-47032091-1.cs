     public class ErrorsFilterAttribute : ExceptionFilterAttribute, IAutofacExceptionFilter
    {
	public override void OnException(HttpActionExecutedContext actionExecutedContext)
	{  
           var errorMessage = new ErrorMessage(actionExecutedContext.Exception.Message, HttpStatusCode.InternalServerError); 
		   if (actionExecutedContext.Exception is NotFoundException)
            {
                errorMessage.ErrorCode = (int)HttpStatusCode.NotFound;
                isWarning = true;
                errorMessage.CodeAction = ((NotFoundException) actionExecutedContext.Exception).CodeAction; 
		    }
			  actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse((HttpStatusCode)errorMessage.ErrorCode, errorMessage);
    }
	}
