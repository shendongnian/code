    public class BaseExcpetion()
    {
       public CustomError CustomError {get;set;}
       public BaseExcption()
       {
         this.CustomError  = new CustomError ();
       }
    }
__________________________________________
       public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
        {
            class CustomError
            {
                public int code { get; set; }
                public String message { get; set; }
            }
    
            public override void OnException(HttpActionExecutedContext context)
            {
                  if (context.Exception is NotImplementedException)
                    {
                    NotImplementedException exception = (NotImplementedException)context.Exception;
                        HttpError error = new HttpError();
                        CustomError customError = new CustomError
                        {
                            code=123,
                            message="Custom message"
                        };
                        error.Add("error", customError);
                        context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
                    }
                    else
                    {
                        context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                    }
            }
        }
