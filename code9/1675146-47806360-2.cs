    try
    {
    	using (request.GetResponse() as HttpWebResponse)
    	{
    	}
    }
    catch (WebException e)
    {
    	var location = e.Response.Headers["Location"];
    }
