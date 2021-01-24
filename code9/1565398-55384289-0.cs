    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    
    namespace WebApplication1.Filters
    {
        public class ServiceCallAuthorization : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var serviceName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
                var methodName = actionContext.ActionDescriptor.ActionName;
            }
        }
    }
