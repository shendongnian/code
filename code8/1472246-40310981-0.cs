    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class DenyRegularUser  : AuthorizeAttribute
    {
        public DenyRegularUser() :
            base()
        {
    
        }
    
        protected override bool IsAuthorized (System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (AuthorizeRequest(actionContext))
            {
                return true;
            }
            return false;
        }
    
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Code to handle unauthorized request
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.TemporaryRedirect);
            actionContext.Response.Headers.Add("Location", "~/Index/Subscribe");
        }
    
        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //Write your code here to perform authorization
        }
    }
