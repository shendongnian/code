    public class CustomAuthorization : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			actionContext.Response = new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.Forbidden,
				Content = new StringContent("You are unauthorized to access this resource")
			};
		}
	}
