    public class BasicHttpAuthorizationOperationHandler : HttpOperationHandler
    {
     
        BasicHttpAuthorizationAttribute basicHttpAuthorizationAttribute;
     
        public BasicHttpAuthorizationOperationHandler(BasicHttpAuthorizationAttribute authorizeAttribute)
            : base("response")
        {
            basicHttpAuthorizationAttribute = authorizeAttribute;
        }
     
        protected override HttpRequestMessage OnHandle(HttpRequestMessage input)
        {
            if (Authenticate(input))
            {
                return input;
            }
            else
            {
                var challengeMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
                throw new HttpResponseException(challengeMessage);
            }
        }
     
        private bool Authenticate(HttpRequestMessage input)
        {
            if (basicHttpAuthorizationAttribute.RequireSsl &amp;&amp; !HttpContext.Current.Request.IsSecureConnection &amp;&amp; !HttpContext.Current.Request.IsLocal) return false;
     
            if (!HttpContext.Current.Request.Headers.AllKeys.Contains("Authorization")) return false;
     
            string authHeader =  HttpContext.Current.Request.Headers["Authorization"];
     
            IPrincipal principal;
            if (TryGetPrincipal(authHeader, out principal))
            {
                HttpContext.Current.User = principal;
                return true;
            }
            return false;
        }
     
        private bool TryGetPrincipal(string authHeader, out IPrincipal principal)
        {
            var creds = ParseAuthHeader(authHeader);
            if (creds != null)
            {
                if (TryGetPrincipal(creds[0], creds[1], out principal)) return true;
            }
     
            principal = null;
            return false;
        }
     
        private string[] ParseAuthHeader(string authHeader)
        {
            // Check this is a Basic Auth header
            if (authHeader == null || authHeader.Length == 0 || !authHeader.StartsWith("Basic")) return null;
     
            // Pull out the Credentials with are seperated by ':' and Base64 encoded
            string base64Credentials = authHeader.Substring(6);
            string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(base64Credentials)).Split(new char[] { ':' });
     
            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[0])) return null;
     
            // Okay this is the credentials
            return credentials;
        }
     
        private bool TryGetPrincipal(string userName, string password, out IPrincipal principal)
        {
            // this is the method that does the authentication
            // you can replace this with whatever logic you'd use, but proper separation would put the
     
            if (userName.Equals("test") &amp;&amp; password.Equals("test"))
            {                
                principal = new GenericPrincipal(new GenericIdentity(userName), new string[] {"Admin", "User"});
     
                return true;
            }
            else
            {
                principal = null;
                return false;
            }
        }
    }
