    private static T Call<T>(string url, string body)
    {
        var contentBytes = Encoding.UTF8.GetBytes(body);
        var request = (HttpWebRequest)WebRequest.Create(url);
    
        request.Timeout = 60 * 1000;
        request.ContentLength = contentBytes.Length;
        request.Method = "POST";
        request.ContentType = @"application/json";
    
        using (var requestWritter = request.GetRequestStream())
            requestWritter.Write(contentBytes, 0, (int)request.ContentLength);
    
        var responseString = string.Empty;
        var webResponse = (HttpWebResponse)request.GetResponse();
        var responseStream = webResponse.GetResponseStream();
        using (var reader = new StreamReader(responseStream))
            responseString = reader.ReadToEnd();
    
        return JsonConvert.DeserializeObject<T>(responseString);
    }
