    public class SessionTimeoutAttribute: AuthorizeAttribute {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext) {
    
            base.HandleUnauthorizedRequest(actionContext);
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
              
        }
    }
