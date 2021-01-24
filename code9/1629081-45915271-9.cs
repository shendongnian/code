    public class ValidateAntiForgeryTokenEveryPost : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.HttpContext.Request.HttpMethod == "POST")
            {
                System.Web.Helpers.AntiForgery.Validate();
            }
        }
    }
