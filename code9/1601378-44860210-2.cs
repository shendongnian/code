    public class ModifyResultFilter : IAsyncResultFilter
    {
        public ModifyResultFilter(IOptions<MvcJsonOptions> optionsAccessor)
        {
            _globalSettings = optionsAccessor.Value.SerializerSettings;
        }
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var originResult = context.Result as JsonResult;
            context.Result = new JsonResult(originResult.Value, customSettings);
            await next();
        }
    }
