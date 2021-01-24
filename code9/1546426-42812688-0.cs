    static string TestURL(string baseURL)
    {
        try
        {
            string httpsURL = "https://" + baseURL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsURL);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return request.RequestUri.Scheme;
        }
        catch
        {
            string httpURL = "http://" + baseURL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpURL);
            //request.Method = "GET";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return request.RequestUri.Scheme;
        }
    }
