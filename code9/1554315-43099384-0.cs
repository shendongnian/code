    public static Task<WebResponse> GetResponseAsync()
    {
        var http = (HttpWebRequest)WebRequest.Create(Connection.GetUri(path).Uri);
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = "POST";
    
        var parsedContent = JsonConvert.SerializeObject(value);
        var encoding = new ASCIIEncoding();
        var bytes = encoding.GetBytes(parsedContent);
    
        var newStream = http.GetRequestStream();
        newStream.Write(bytes, 0, bytes.Length);
        newStream.Close();
        Task<WebResponse> task = Task.Factory.FromAsync(
            http.BeginGetResponse,
            asyncResult => http.EndGetResponse(asyncResult),
            (object)null);
    
        return task;
    }
