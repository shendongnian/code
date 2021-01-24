    public class CustomAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var response = mydata.Result.Content.ReadAsStringAsync();
            if (mydata.Result.StatusCode == HttpStatusCode.OK)
            {
                actionContext.Request.Properties["keyName"] = keyValue;
                return true;
            }
        }
    }
