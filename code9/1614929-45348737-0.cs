    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resturl + "authenticate");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            request.Accept = "application/json";
            request.ProtocolVersion = HttpVersion.Version11;
    // Set your Response body
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        string json = "{\"user\":\"" + restlogin + "\"," +
                      "\"pwd\":\"" + restpassword + "\"}";
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    if (response.StatusCode == HttpStatusCode.OK)
    {
         using (Stream respStream = response.GetResponseStream())
         {
             StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
             token = reader.ReadToEnd();
             reader.Close();
             reader.Dispose();
             response.Close();
         }
    }
