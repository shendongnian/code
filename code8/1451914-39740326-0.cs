    public class IdentityProvider : IIdentityProvider
    {
        public IPrincipal GetPrincipal()
        {
            return HttpContext.Current.User;
        }
    }
