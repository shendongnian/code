    public class TokenAuthenticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // this will read `token` parameter from your URL
            ValueProviderResult valueProvided = filterContext.Controller.ValueProvider.GetValue("token");
            if (valueProvided == null)
            {
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
            var providedToken = valueProvided.AttemptedValue;
            var storedToken = "12345"; // <-- get your token value from DB or something
            if (storedToken != providedToken)
            {
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }
