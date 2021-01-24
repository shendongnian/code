    public class CustomActionJsonFormatAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext?.Response == null) return;
    
            var content = actionExecutedContext.Response.Content as ObjectContent;
    
            if (content?.Formatter is JsonMediaTypeFormatter)
            {
                var formatter = new JsonMediaTypeFormatter
                {
                    SerializerSettings =
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                };
    
                actionExecutedContext.Response.Content = new ObjectContent(content.ObjectType, content.Value, formatter);
            }
        }
    }
    
    public class MyController : ApiController
    {
        [CustomActionJsonFormat]
        public IHttpActionResult Get()
        {
            var model = new MyModel();
            return Ok(model);
        }
    }
