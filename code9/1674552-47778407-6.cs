    public override void Handle(ExceptionHandlerContext context)
    {
       string errorMessage = "An unexpected error occured";
         var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                        new ErrorInformation() 
                        {
                            Message = "We apologize but an unexpected error occured. Please try again later.",
                            ErrorDate = DateTime.UtcNow 
                        }
                      );
       response.Headers.Add("X-Error", errorMessage);
       context.Result = new ResponseMessageResult(response); 
    }
