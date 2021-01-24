    public class AuthorizationFilter : AuthorizeAttribute
    {
                
                protected override bool IsAuthorized(HttpActionContext actionContext)
                {
                    var isAuthenticated = base.IsAuthorized(actionContext);
    
                    if (isAuthenticated)
                    {
                         var headers = actionContext.Request.Headers;
                         IEnumerable<string> header;
                         headers.TryGetValues("AuthorizationHeaderName", out header);
                         var token = header.GetEnumerator().Current;
                         //validate your token
                         if (tokenVerification(token))
                         {
                            return true;
                         }
                         return false;
                     }
    
                }
       
          private bool tokenVerification (string token)
          {
              if // valid token
               return true;
              else return false;
          }
    }
