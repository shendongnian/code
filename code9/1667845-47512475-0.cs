    public class CustomAuthenticationAttribute : ActionFilterAttribute, 
    IAuthenticationFilter
    {
      public void OnAuthentication(AuthenticationContext filterContext)
      {            
      }
      public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
      {            
      }
    }
