    public override void OnException(ExceptionContext context)
        {
          if (context.Exception is MyServiceOperationException)
          {
            context.Result = new BadRequestObjectResult(new MyErrorResult(){ 
              Message = context.Exception.Message,
              Code=context.Exception.MyErrorCode }
              );
          }
    }
