    services.AddMvc(options =>
            {
                options.Filters.Add(new MyValidationFilterAttribute());
                //Some other code
            }
    public class MyValidationFilterAttribute: IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;
            if (!RequestRecognizingUtils.IsMobileAppRequest(context.HttpContext.Request))
                return; //Here all validation results are ignored
        }
    }
