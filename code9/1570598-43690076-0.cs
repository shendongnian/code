    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("Url");
    StreamWriter streamWriter;
    try
    {
        streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        streamWriter.Write("body");
        using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
        {
            string json = streamReader.ReadToEnd();
        }
    }
    finally
    {
        streamWriter.Dispose();
    }
