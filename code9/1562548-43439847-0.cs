    ...
    httpWebRequest.CookieContainer = new CookieContainer();
    using (var stream = httpWebRequest.GetRequestStream())
    {
        stream.Write(postDataBytes, 0, postDataBytes.Length);
        stream.Close();
    }
    using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
    {
        var cookieContainer = new CookieContainer();
        cookieContainer.Add(httpWebResponse.Cookies);
        return cookieContainer;
    }
