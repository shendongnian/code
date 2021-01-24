    var ub = new UriBuilder("https://api.stackexchange.com/2.2/search/advanced");
    // query string parameters
	var query = new Dictionary<string,string> ();
	query.Add("site", "stackoverflow");
	query.Add("q", "[c#] OR [f#]");
	
    // iterate over each dictionary item and UrlEncode the value
	ub.Query = String.Join("&",
		query.Select(kv => kv.Key + "=" + WebUtility.UrlEncode(kv.Value)));
    ub.Uri.AbsoluteUri.Dump("builder");
	
