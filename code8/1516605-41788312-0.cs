    public static async Task<HttpWebResponse> Get(string requestUrl, Dictionary<string, string> headers, string contentType, string acceptType, string userAgent)
    {
        //Create http Request
        HttpWebRequest httprequest = WebRequest.Create(requestUrl) as HttpWebRequest;
        //Add all headers.
        httprequest.ContentType = contentType;
        httprequest.Accept = acceptType;
        httprequest.Headers[HttpRequestHeader.UserAgent] = userAgent;
        foreach (var header in headers)
        {
            httprequest.Headers[header.Key] = header.Value;
        }
        httprequest.Method = "GET";
        //Get response
        HttpWebResponse response = await httprequest.GetResponseAsync() as HttpWebResponse;
        return response;
    }
