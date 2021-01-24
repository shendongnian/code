    HttpCookie updatedCookie = Request.Cookies["CartCookie"];
    if (updatedCookie == null)
    {
    	// [omitted]
    }
    else
    {
    	// update the cookie values
    	foreach (KeyValuePair<string, string> kvp in keyValuePairs)
    	{
    		System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
    		updatedCookie.Values[kvp.Key] = kvp.Value;
    	}
    }
