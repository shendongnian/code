    String url = // a valid url
    String requestXml = File.ReadAllText(filePath);//opens file , reads all text and closes it
    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Credentials = new NetworkCredential("DEFAULT\\Admin", "Admin"); 
    request.ContentType = "application/xml";
    request.ContentLength = bytes.Length;
    request.Method = "POST";
    request.KeepAlive = false;
    using (Stream requestStream = request.GetRequestStream())
    {
        requestStream.Write(bytes, 0, bytes.Length);
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
