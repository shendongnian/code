    public class ValidateAntiForgeryTokenEveryPost : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            // adapted from Darin Dimitrov (/a/34588606/)
            bool isValidate = !context.ActionDescriptor.GetCustomAttributes(typeof(ExcludeAntiForgeryCheckAttribute), true).Any();
    
            // use AND operator (&&) if you want to exclude POST requests marked with custom attribute
            // otherwise, use OR operator (||)
            if (context.HttpContext.Request.HttpMethod == "POST" && isValidate)
            {
                System.Web.Helpers.AntiForgery.Validate();
            }
        }
    }
