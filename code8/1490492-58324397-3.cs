	private static async Task<string> RenderToStringAsync(ViewResult viewResult, IServiceProvider serviceProvider)
	{
		if (viewResult == null) throw new ArgumentNullException(nameof(viewResult));
		var httpContext = new DefaultHttpContext
		{
			RequestServices = serviceProvider
		};
		var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
		using (var stream = new MemoryStream())
		{
			httpContext.Response.Body = stream; // inject a convenient memory stream
			await viewResult.ExecuteResultAsync(actionContext); // execute view result on that stream
			httpContext.Response.Body.Position = 0;
			return new StreamReader(httpContext.Response.Body).ReadToEnd(); // collect the content of the stream
		}
	}
