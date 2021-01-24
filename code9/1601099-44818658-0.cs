    public class AuthenticationFilter : AuthorizationFilterAttribute
            {
                /// <summary>
                /// read requested header and validated
                /// </summary>
                /// <param name="actionContext"></param>
                public override void OnAuthorization(HttpActionContext actionContext)
                {
                    var identity = FetchFromHeader(actionContext);
        
                    if(identity != null)
                    {
                        //get the user based on the identity
                        var user=TokenService.getUserFromToken(identity);
                        if (user)
                        {
                            CurrentThread.SetPrincipal(new GenericPrincipal(new GenericIdentity(user), null), null, null);
                        }
                        else
                        {
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                            return;
                        }
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        return;
                    }
                    base.OnAuthorization(actionContext);
                }
        
                /// <summary>
                /// retrive header detail from the request 
                /// </summary>
                /// <param name="actionContext"></param>
                /// <returns></returns>
                private string FetchFromHeader(HttpActionContext actionContext)
                {
                    string requestToken = null;
        
                    var authRequest = actionContext.Request.Headers.Authorization;
                    if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                        requestToken = authRequest.Parameter;
        
                    return requestToken;
                }
            }
