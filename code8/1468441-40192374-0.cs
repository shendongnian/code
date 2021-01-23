    try
    {
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }
    catch(WebException ex)
    {
        var httpResponse = ex.Response as HttpWebResponse;
        if (httpResponse != null)
        {
            // process the response
        }
    }
