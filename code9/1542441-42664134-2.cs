    public class CustomAuthorizeAttribute  : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var prop1 = HttpContext.Current.Request.Params["Prop1"];
            var prop2 = HttpContext.Current.Request.Params["Prop2"];
            bool conditions = // add conditions based on above properties
            if(conditions)
            {
                return true;
            }
    
            return false;
        }        
    }
