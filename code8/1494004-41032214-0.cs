    public class TokenValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");
    
            var authorization = actionContext.Request.Headers.Authorization;
            if (authorization != null)
            {
                var authToken = authorization.Parameter;
                var token = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
    
                if ("Authorized Token" == token)
                    return;
            }
    
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
    
    public class IpHostValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var context = actionContext.Request.Properties["MS_HttpContext"] 
               as HttpContextBase;
            string ipAddress = context.Request.UserHostAddress;
    
            if (ipAddress == "Authorized IP Address")
                return;
    
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent("Unauthorized IP Address")
            };
        }
    }
