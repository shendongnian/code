    **[BasicAuth]**
    	/// <summary>
    /// Basic Authentication Filter Class
    /// </summary>
    public class BasicAuthAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            try
            {
                if (filterContext.Request.Headers.Authorization == null)
                {
                    // Client authentication failed due to invalid request.
                    
                    filterContext.Response = new System.Net.Http.HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        Content = new StringContent("{\"error\":\"invalid_client\"}", Encoding.UTF8, "application/json")
                    };
                    filterContext.Response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=xxxx"));
                }
                else if (filterContext.Request.Headers.Authorization.Scheme != "Basic" ||
                    string.IsNullOrEmpty(filterContext.Request.Headers.Authorization.Parameter))
                {
                    // Client authentication failed due to invalid request.
                    filterContext.Response = new System.Net.Http.HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("{\"error\":\"invalid_request\"}", Encoding.UTF8, "application/json")
                    };
                }
                else
                {
                    var authToken = filterContext.Request.Headers.Authorization.Parameter;
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string usernamePassword = encoding.GetString(Convert.FromBase64String(authToken));
                    int seperatorIndex = usernamePassword.IndexOf(':');
                    string clientId = usernamePassword.Substring(0, seperatorIndex);
                    string clientSecret = usernamePassword.Substring(seperatorIndex + 1);
                    if (!ValidateApiKey(clientId, clientSecret))
                    {
                        // Client authentication failed due to invalid credentials
                        filterContext.Response = new System.Net.Http.HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.Unauthorized,
                            Content = new StringContent("{\"error\":\"invalid_client\"}", Encoding.UTF8, "application/json")
                        };
                    }
                    // Successfully finished HTTP basic authentication
                }
            }
            catch (Exception ex)
            {
                // Client authentication failed due to internal server error
                filterContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("{\"error\":\"invalid_request\"}", Encoding.UTF8, "application/json")
                };
            }
        }
        
        
        /// <summary>
        /// Validates the API key.
        /// </summary>
        /// <param name="recievedKey">The recieved key.</param>
        /// <returns></returns>
        private bool ValidateApiKey(string clientId, string clientSecret)
        {
            if (your condition satisfies)
            {
				return true;
            }
            return false;
        }
    }
