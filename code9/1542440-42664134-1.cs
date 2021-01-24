    public class CustomAuthorizeAttribute  : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            XyzModel model = (XyzModel)actionContext.ActionArguments["model"];
            bool conditions = // add conditions based on model object
            if(conditions)
            {
                return true;
            }
    
            return false;
        }        
    }
