    using System.Security.Principal;    
    public class DefaultPrincipalProvider : IPrincipalProvider
    {
        public IPrincipal User
        {
            get
            {
                return HttpContext.Current.User;
            }
        }
    } 
