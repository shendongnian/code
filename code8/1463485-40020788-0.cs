    public void POST(Messages messages)
    {
        var request = (HttpWebRequest)WebRequest.Create("http://localhost:13060/Default/Index");
        request.ContentType = "application/json";
        request.Method = "POST";
        
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            string json = new JavaScriptSerializer().Serialize(messages);
            streamWriter.Write(json);
        }
        
        var response = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }
