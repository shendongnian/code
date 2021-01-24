    public class ControllerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        public ControllerExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }
        public override void OnException(ExceptionContext context)
        {
            //How construct a temp data here which I want to pass to error page?
            var tempData = _tempDataDictionaryFactory.GetTempData(context.HttpContext);
            var result = new ViewResult
            {
                ViewName = "Error"
            };
            context.ExceptionHandled = true; // mark exception as handled
            context.Result = result;
        }
    }
