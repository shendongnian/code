    public class TokenAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            string token = Convert.ToString(filterContext.RouteData.Values["token"]);
            // do your authentication stuff            
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
