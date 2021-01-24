    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    using (var streamWriter = new 
    StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = new JavaScriptSerializer().Serialize(new
                    {
                        Username = "myusername",
                        Password = "password"
                    });
    
        streamWriter.Write(json);
    }
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
    
