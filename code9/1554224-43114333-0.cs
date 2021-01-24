      public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var queryStringValues = actionContext.Request.GetQueryNameValuePairs();
            var customerGuid = queryStringValues.FirstOrDefault(x => x.Key == "customerGuid").Value;
            //Your logic
        }
    }
