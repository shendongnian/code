    public class TestIdentityFilter :  FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.Principal = new GenericPrincipal(
                new GenericIdentity(),
                new string [] {"Administrator"});
        }
    }
