         public class ApiAuthorizationFilterAttribute : AuthorizeAttribute {
        
        /// <summary>
        /// Performs custom authorization based on incoming request  
        ///  value(header)
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext) {
            //Checking for any controller decorated with AllowAnonymousAttribute
            bool skipAuthorization = actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (skipAuthorization) {
                return;
            }
            if (!IsAuthorized(actionContext)) {
                actionContext.Response = ApiHttpResponseMessage.HandleUnauthorizedRequest(actionContext.Request);
                return;
            }
            if (!IsUserAuthorized(actionContext)) {
                actionContext.Response = ApiHttpResponseMessage.CreateResponse(actionContext.Request, ErrorMessages.INVALID_CMF_EXCEPTION_MESSAGE, HttpStatusCode.Forbidden);
            }
        }
