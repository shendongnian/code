    public class ExceptionGlobalFilter : ExceptionFilterAttribute
    {
        private readonly ILogger logger;
        public ExceptionGlobalFilter(ILoggerFactory lf)
        {
            logger = lf.CreateLogger("ExceptionGlobalFilter");
        }
        public override void OnException(ExceptionContext context)
        {
            var customObject = new CustomObject(context.Exception);
            //TODO: Add logs
            if (context.Exception is BadRequestException)
            {
                context.Result = new BadRequestObjectResult(customObject);
            }
            else if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundObjectResult(customObject);
            }
            else
            {
                context.Result = new OkObjectResult(customObject);
            }
            base.OnException(context);
        }
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            await base.OnExceptionAsync(context);
            return;
        }
    }
