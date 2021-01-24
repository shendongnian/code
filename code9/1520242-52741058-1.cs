	public class HeaderAuthenticationAttribute : AuthorizeAttribute
	{
		private bool invalidApiKey = false;
		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			bool isExitsInHeader = actionContext.Request.Headers.TryGetValues("ApiKey", out IEnumerable<string> headerValues);
			if (isExitsInHeader && headerValues.Any(x => x.Contains("foo")))
			{
				return true;
			}
			else if (isExitsInHeader && !headerValues.Any(x => x.Contains("foo")))
			{
				return false;
			}
			else
			{
				invalidApiKey = true;
				return false;
			}
		}
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			//check if response has header indicating invalid api key
			if (invalidApiKey)
			{
				actionContext.Response = new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.MethodNotAllowed,
					Content = new StringContent("errorMessage here")
				};
			}
			else
			{
				actionContext.Response = new HttpResponseMessage()
				{
					StatusCode = HttpStatusCode.Forbidden,
					Content = new StringContent("someOther message here")
				};
			}
			// log here
		}
	}
