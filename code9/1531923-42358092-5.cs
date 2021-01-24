       public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
        {
            private readonly IHostingEnvironment _hostingEnvironment;
        
            public CustomExceptionFilterAttribute(
                IHostingEnvironment hostingEnvironment,
                IModelMetadataProvider modelMetadataProvider)
            {
                _hostingEnvironment = hostingEnvironment;
            }
        
            public override void OnException(ExceptionContext context)
            {
                if (!_hostingEnvironment.IsDevelopment())
                {
                    // do nothing
                    return;
                }
        
                var result = new RedirectToRouteResult(
    new RouteValueDictionary(new { controller = "Home", action = "Error" }));
                context.Result = result;
            }
        }
