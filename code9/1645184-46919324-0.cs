	public override RouteData GetRouteData(HttpContextBase httpContext)
	{
		RouteData result = null;
		// Trim the leading slash
		var path = httpContext.Request.Path.Substring(1);
		// Get the page that matches.
		var page = GetPageList(httpContext)
			.Where(x => x.VirtualPath.Equals(path))
			.FirstOrDefault();
		if (page != null)
		{
			result = new RouteData(this, new MvcRouteHandler());
			// Optional - make query string values into route values.
			AddQueryStringParametersToRouteData(result, httpContext);
			result.Values["controller"] = page.Controller;
			result.Values["action"] = page.Action;
		}
		// IMPORTANT: Always return null if there is no match.
		// This tells .NET routing to check the next route that is registered.
		return result;
	}
