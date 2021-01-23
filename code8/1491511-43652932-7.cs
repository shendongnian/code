	public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame,
		IRequest request, IResponse response)
	{
		/*if (request.Headers["X-Requested-With"] != "XMLHttpRequest" ||
			response.ResponseHeaders["Content-Type"].Contains("application/json")) return null;*/
		if (!response.ResponseHeaders["Content-Type"].Contains("application/json"))
		{
			return null;
		}
		var filter = FilterManager.CreateFilter(request.Identifier.ToString());
		return filter;
	}
	public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
		IResponse response, UrlRequestStatus status, long receivedContentLength)
	{
		if (!response.ResponseHeaders["Content-Type"].Contains("application/json"))
		{
			return;
		}
		var filter = FilterManager.GetFileter(request.Identifier.ToString()) as TestJsonFilter;
		if (filter != null)
			Console.WriteLine(filter.DataAll);
	}
