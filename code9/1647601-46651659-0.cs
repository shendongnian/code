    WebRequest request = 
    WebRequest.Create("http://...");
    WebResponse response = null; 
    try
    {
        response = request.GetResponse();
    }
    catch (WebException webEx)
    {
        if (webEx.Response != null)
        {
            using (var errorResponse = (HttpWebResponse)webEx.Response)
            {
                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                {
                    string error = reader.ReadToEnd();
                    // TODO: use JSON.net to parse this string
                }
            }
        }
    }
