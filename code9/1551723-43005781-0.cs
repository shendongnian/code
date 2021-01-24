    public class SecureMyApi : DelegatingHandler {
    	protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    	{
    			// Extra security stop to verify mobile app should have access to API
    			var httpRequest = HttpContext.Current.Request;
    
    			if (!string.IsNullOrWhiteSpace(httpRequest.UserAgent) && (httpRequest.UserAgent.StartsWith(ConfigurationManager.AppSettings["MyCustomUserAgentString"])))
    			{
    				// Allow user to pass through
    			}
    			else
    			{
    				if (request.Method != HttpMethod.Get)
    				{
    					return request.CreateErrorResponse(HttpStatusCode.BadRequest, "You do not have permission to access the requested endpoint.");
    				}
    			}
    		
    		return await base.SendAsync(request, cancellationToken);
    	}
    }
