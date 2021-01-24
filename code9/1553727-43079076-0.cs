    public class ApiExceptionHandler: ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            LogManager.GetLoggerForCurrentClass().Error(context.Exception, "Captured in ExceptionHandler");
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                context.Result = new NotFoundResult(context.Request);
            }
            else if (context.Exception.GetType() == typeof(ArgumentException))
            {
                // no-op - probably a routing error, which will return a bad request with info
            }
            else if (context.Exception.GetType() == typeof(ArgumentNullException))
            {
                context.Result = new BadRequestResult(context.Request);
            }
            else
            {
                context.Result = new InternalServerErrorResult(context.Request);
            }
        }
    }
