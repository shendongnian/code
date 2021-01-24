    services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(someExceptionFilter));
                })
    public class someExceptionFilter: IExceptionFilter
        {
            public someExceptionFilter()
            {
    
            }
            public void OnException(ExceptionContext context)
            {
                var exceptionType = context.Exception.GetType();
                if (exceptionType == typeof(yourException))
                {
                    context.ExceptionHandled = true;
                    var response = context.HttpContext.Response;
                    
                    response.StatusCode = 429;
                    response.ContentType = "application/json";
                    //response.WriteAsync(context.Exception.Message);
                    context.Result = new JsonResult(context.Exception.Message);
                }
            }
        }
