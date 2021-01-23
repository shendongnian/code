    UriBuilder urb = new UriBuilder("www.google.com");
    Uri uri = urb.Uri;
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
    request.Method = WebRequestMethods.Http.Get;
    string responseString;
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            responseString = reader.ReadToEnd();
        }
    }
