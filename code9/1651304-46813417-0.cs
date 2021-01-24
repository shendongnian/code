    // MyCustomFilter.cs
    public class MyCustomFilter : ActionFilterAttribute
    {
        public string param { get; set; }
    
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            ILogger<MyCustomFilter> logger = (ILogger <MyCustomFilter>)ctx.HttpContext.RequestServices.GetService(typeof(ILogger<MyCustomFilter>));
            IM3ObjectRepository repo = (IM3ObjectRepository)ctx.HttpContext.RequestServices.GetService(typeof(IM3ObjectRepository));
    
            logger.LogInformation("Filter is working.");
            
            // Get stuff from object repository, based on passed-in parameter.
        }
    }
    
    // Example of filter being used.
    [MyCustomFilter(param = "value you want")]
    public IActionResult Action(...)
    {
        ...
    }
