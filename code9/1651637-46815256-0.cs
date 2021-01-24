       public class ValidateModelAttribute : ActionFilterAttribute
            {
                public override void OnActionExecuting(HttpActionContext actionContext)
                {
        
                    if (!actionContext.ModelState.IsValid)
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                    }
                }
        
                public override bool AllowMultiple
                {
                    get { return false; }
                }
            }
    public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
                config.Filters.Add(new ValidateModelAttribute());
            }
        }
