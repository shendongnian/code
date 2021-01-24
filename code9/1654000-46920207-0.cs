    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    
    namespace Attributes
    {
        public class AuthAttribute : ActionFilterAttribute
        {
            private readonly string _action;
            private readonly string _controller;
            private readonly string _role;
            
            public AuthAttribute(string action, string controller, string role)
            {
                _action = action;
                _controller = controller;
                _role = role;
            }
    
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                if (!filterContext.HttpContext.User.IsInRole(_role))
                {
                    filterContext.Result = new RedirectToRouteResult(new {action = _action, controller = _controller});
                }
                else
                {
                    base.OnResultExecuting(filterContext);
                }
            }
        }
    }
