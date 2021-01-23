    try 
    {
        var result = new System.Net.WebClient().DownloadString("BadURL");
        // process result
    }
    catch (WebException webEx)
    {
        var statusCode = ((HttpWebResponse)webEx.Response).StatusCode;
        var body = new StreamReader(webEx.Response.GetResponseStream()).ReadToEnd();
        switch (statusCode) 
        {
            case 404:
               // parse error from your body (or in your case it is your body)
            case ...:
        }
    }
