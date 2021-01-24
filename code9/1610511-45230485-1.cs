    [AntiForgeryUpdate]
    [HttpPost]
    public async Task<EditUserResponse> editUser (EditUserRequest request)
    {
       try
       {
         //code for updating user
         var principal = Request.GetRequestContext().Principal;
         var identity = principal.Identity;
         identity.IdentityInfo = changedUser;
       }
       catch(Exception ex)
       {
          throw;
       }
    }
    public class AntiForgeryUpdate: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Method != HttpMethod.Get)
            {
                AntiForgery.GetTokens(null, out string cookieToken, out string formToken);
                var token = cookieToken + ":" + formToken;
                actionExecutedContext.Response.Headers.AddCookies("XSRF-TOKEN", token);
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
