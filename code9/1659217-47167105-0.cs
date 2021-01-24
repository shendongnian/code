    /// <summary>
    /// Simple action filter to prevent executing the action for certain http methods
    /// </summary>
    public class SwaggerIgnore : ActionFilterAttribute
    {
        string[] _ignoreMethods;
    
        /// <summary>
        /// Ignores the request when coming from Swagger. 
        /// 
        /// Will return a default OK result.
        /// 
        /// Handy if you want to allow the "try" button, but not allow changes to entities; such as HttpDelete
        /// </summary>
        /// <param name="ignoreMethods">List of methods to ignore; get, delete etc</param>
        public SwaggerIgnore(string[] ignoreMethods)
        {
            _ignoreMethods = ignoreMethods.Select(s => s.ToLower()).ToArray();
        }
    
    
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string methodExecuting = context.HttpContext.Request.Method.ToLower();
            string referrer = context.HttpContext.Request.Headers["Referer"].ToString().ToLower();
            if (_ignoreMethods.Contains(methodExecuting) && referrer.Contains("swagger"))
                context.Result = new OkResult();
            else
                base.OnActionExecuting(context);
        }
    }
