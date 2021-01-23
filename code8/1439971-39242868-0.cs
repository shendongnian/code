	public class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		public CustomAuthorizeAttribute() : base()
		{
		}
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
			{
				var response = new HttpResponseMessage(HttpStatusCode.NotFound);
				string message =
					"<!DOCTYPE html><html><head><title> Page Not Found </title></head><body><h2 style='text-align:center'> Sorry, Page Not Found </h2></body></html>";
				response.Content = new StringContent(message);
				response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
				actionContext.Response = response;
			}
		}
	}
