    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://yourUrl");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = "{\"Username\":\"myusername\"," +
                      "\"Password\":\"pass\"}";
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
    
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
