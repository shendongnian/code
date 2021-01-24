      public class MyCustomAuthAttribute : AuthorizeAttribute
      {
          protected virtual void HandleUnauthorizedRequest(HttpActionContext actionContext)
            {
                if (actionContext == null)
                {
                    throw Error.ArgumentNull("actionContext");
                }
        
                    actionContext.Response =
                    actionContext.ControllerContext.Request.CreateErrorResponse(
                                          HttpStatusCode.Unauthorized, 
                                          "My Un-Authorized Message");
          }
        } 
   
