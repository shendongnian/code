    public class TutorAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;
            RequestValidator validator = new RequestValidator(); 
		    if(validator.IsValid(request))
		    {
			    return; 
		    }
		
            filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", $"Basic realm= {BasicRealm}");
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
