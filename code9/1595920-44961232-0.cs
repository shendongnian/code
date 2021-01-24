    String endPoint = @"http://example.com/v1/api/";
    String json = @"....";//Example JSON string
    Byte[] jsonData = Encoding.UTF8.GetBytes(json);
    StreamWriter file = new StreamWriter(@"File Location");
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
    request.Method = "POST";
    request.ContentType = "text/plain";
    request.KeepAlive = false;
    request.AllowReadStreamBuffering = false;
    request.ContentLength = jsonData.Length;
    /* Pretend this middle part does the Authorization with username and password. */
    /* I have actually authenticated using the above method, and passed a key to the request */
     //This part POST the JSON to the API
     Stream writeStream = request.GetRequestStream();
     writeStream.Write(jsonData, 0, jsonData.Length);
     //This conducts the reading/writing into the file
     HttpWebResponse response = (HttpWebResponse)request.GetResponse();
     using (Stream receivedStream = response.GetResponseStream())
     using (BufferedStream bs = new BufferedStream(receivedStream))
     using (StreamReader sr = new StreamReader(bs))
     {
           String s;
           while ((s = sr.ReadLine()) != null)
           {
                file.WriteLine(s);
            }
     }
