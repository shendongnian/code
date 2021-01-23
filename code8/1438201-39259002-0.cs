    public class MyExceptionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                actionExecutedContext.Response.Content = new StringContent("An error occurred.");
            }
        }
    }
