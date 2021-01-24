	void Application_BeginRequest(object sender, EventArgs e)
	{
		if (!Request.Url.Authority.StartsWith("www"))
			return;
		var url = string.Format("{0}://{1}{2}",
			Request.Url.Scheme,
			Request.Url.Authority,
			Request.Url.PathAndQuery);
			Response.RedirectPermanent(url, true);
	}
