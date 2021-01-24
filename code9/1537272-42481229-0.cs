     public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            
            public CustomAuthorizeAttribute ()
            {
               
            }
    
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                try
                {
                    if (Authorize(actionContext))
                    {
                        return;
                    }
                    HandleUnauthorizedRequest(actionContext);
                }
                catch (Exception)
                {
                    //create custom response
                    actionContext.Response = actionContext.Request.CreateResponse(
                        HttpStatusCode.OK,
                        customresponse
                    );
                    return;
                }
    
            }
    
            protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
            {
                //create custom unauthorized response
               
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK,
                    customunauthorizedresponse
                );
                return;
            }
    
            private bool Authorize(HttpActionContext actionContext)
            {
                //authorization logics
            }
    
            
        }
