    public class ValidModelStateAsyncActionFilter : IAsyncActionFilter
    {
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage?view=aspnetcore-2.1
        private static readonly Action<ILogger, IList<(string Key, string ErrorMessage, string ExceptionMessage)>, Exception> ModelStateLoggerAction;
        private readonly ILogger<ValidModelStateAsyncActionFilter> logger;
        static ValidModelStateAsyncActionFilter()
        {
            ModelStateLoggerAction = LoggerMessage.Define<IList<(string Key, string ErrorMessage, string ExceptionMessage)>>(LogLevel.Warning, new EventId(1, nameof(ValidModelStateAsyncActionFilter)), "{ModelState}");
        }
        public ValidModelStateAsyncActionFilter(ILogger<ValidModelStateAsyncActionFilter> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
                await next();
            this.LogModelState(context);
            context.Result = new BadRequestObjectResult(GetErrorResponse(context));
        }
        private static ErrorResponse GetErrorResponse(ActionContext context)
        {
            return new ErrorResponse
            {
                ErrorType = ErrorTypeEnum.ValidationError,
                Message = "The input parematers are invalid.",
                Errors = context.ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList()
            };
        }
        private void LogModelState(ActionContext context)
        {
            // credit: https://blogs.msdn.microsoft.com/mazhou/2017/05/26/c-7-series-part-1-value-tuples/
            var items = from ms in context.ModelState
                        where ms.Value.Errors.Any()
                        let fieldKey = ms.Key
                        let errors = ms.Value.Errors
                        from error in errors
                        select (Key: fieldKey, ErrorMessage: error.ErrorMessage, ExceptionMessage: error.Exception.Message);
            ModelStateLoggerAction(this.logger, items.ToList(), null);
        }
    }
