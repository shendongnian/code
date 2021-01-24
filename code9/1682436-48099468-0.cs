    public class AuthorizeUserToClubAttribute : AuthorizeAttribute
    {   
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            //Get route data from context
            //Get current user from context
            //Ceck does user has an access and write result into variable
            return result;
        }
    }
