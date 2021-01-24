    public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services   
    
                // Web API routes
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
    
                //config.Services.Add(typeof(IExceptionLogger), new AiExceptionLogger());
    
                config.Filters.Add(new AAA());
            }
    
            public class AAA : ActionFilterAttribute
            {
    
                public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
                {
                    if (actionExecutedContext.Exception != null)
                    {
                        var ai = new TelemetryClient();
                         //here get the arguments
                        string d1 = (string)actionExecutedContext.ActionContext.ActionArguments["id"];
                        var properties = new Dictionary<string, string> { { "Users", d1 } };
                        ai.TrackException(actionExecutedContext.Exception, properties);
                    }
                    base.OnActionExecuted(actionExecutedContext);
                }
            }
