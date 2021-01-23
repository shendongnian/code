    const string mySessionIdentifier = "mySessionId";
    // Converts incoming requests with "mySessionId" cookie to "ss-id"
    PreRequestFilters.Add((IRequest httpReq, IResponse httpRes) =>
	{
		var cookie = httpReq.Cookies[mySessionIdentifier];
		if (cookie != null)
		{
			httpReq.Cookies.Remove(mySessionIdentifier);
			httpReq.Cookies.Add(ServiceStack.Keywords.SessionId, cookie);
		}
    }
    // Converts responses with outgoing cookie "ss-id" to "mySessionId"
    GlobalResponseFilters.Add((IRequest httpReq, IResponse httpRes, object dto) => {
	    var cookies = httpRes.CookiesAsDictionary();
		string cookie;
		if (cookies.TryGetValue(ServiceStack.Keywords.SessionId, out cookie))
		{
		    httpRes.DeleteCookie(ServiceStack.Keywords.SessionId);
			httpRes.SetCookie(new Cookie(mySessionIdentifier, cookie));
		}
	});
