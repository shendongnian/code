    private static T Call<T>(string url, string body, int timeOut = 60)
    {
        var contentBytes = Encoding.UTF8.GetBytes(body);
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Timeout = timeOut * 1000;
        request.ContentLength = contentBytes.Length;
        request.Method = "DELETE";
        request.ContentType = @"application/json";
        using (var requestWritter = request.GetRequestStream())
            requestWritter.Write(contentBytes, 0, (int)request.ContentLength);
        var responseString = string.Empty;
        var webResponse = (HttpWebResponse)request.GetResponse();
        var responseStream = webResponse.GetResponseStream();
        using (var reader = new StreamReader(responseStream))
        {
            reader.BaseStream.ReadTimeout = timeOut * 1000;
            responseString = reader.ReadToEnd();
        }
        return JsonConvert.DeserializeObject<T>(responseString);
    }
