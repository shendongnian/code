    public class MessageHandler1 : DelegatingHandler
	{
    	protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
        	IEnumerable<string> lang;
	        request.Headers.TryGetValues("lang", out lang);
	        MyResource.Culture = new System.Globalization.CultureInfo(lang.FirstOrDefault());
	        var response = await base.SendAsync(request, cancellationToken);
	        return response;
	    }
	}
