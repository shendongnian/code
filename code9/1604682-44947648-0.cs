    public HttpWebRequest CreateRequest(string Url, string Method, string ContentType, object Content, List<RequestHeader> headers)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = Method;
        if (!string.IsNullOrWhiteSpace(ContentType)) request.ContentType = ContentType;
        else if(Content != null) request.ContentType = "application/json";
        if (Content != null)
        {
            var postData = Newtonsoft.Json.JsonConvert.SerializeObject(Content);
            var data = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        foreach(RequestHeader header in Headers)
        {
            request.Headers.Add(header.Type, header.Value);
        } //class at the end.
        return request;
    }
            
    public string GetResponse(HttpWebRequest request)
    {
        var retval = "";
        try
        {
            var response = (HttpWebResponse)request.GetResponse();
            retval = ReadResponse(response);
            response.Close();
        }
        catch (Exception ex)
        {
            resolveException(ex.Message);
        }
        return retval;
    }
    public string ReadResponse(HttpWebResponse response)
    {
        var retval = "";
        try
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var responseText = reader.ReadToEnd();
                retval = responseText;
            }
        }
        catch (Exception ex)
        {
            resolveException(ex.Message);
        }
        return retval;
    }
    public class RequestHeader
    {
        public HttpRequestHeader Type { get; set; }
        public string Value { get; set; }
    }
