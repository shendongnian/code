    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public int Limit { get; set; } // some custom parameters passed from Action
        private ICustomService CustomService { get; } // this must be resolved
        public MyActionFilterAttribute(ICustomService service, int limit)
        {
            CustomService = service;
            Limit = limit;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }
    }
