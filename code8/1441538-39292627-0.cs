    public static bool DownloadFile(string filenameXML){
    HttpWebRequest request;
    HttpWebResponse response = null;
    FileStream fs = null;
    long startpoint = 0;
    NewSourceFilePath=filenameXML;
			
    fs = File.Create(NewSourceFilePath);
    request = (HttpWebRequest)WebRequest.Create("http://---/file.zip");
    request.KeepAlive = false;
    request.ProtocolVersion = HttpVersion.Version11;
    request.Method = "GET";
    request.ContentType = "gzip";
    request.Timeout=10000;
    request.Headers.Add("xRange", "bytes " + startpoint + "-");
    response = (HttpWebResponse)request.GetResponse();
    Stream streamResponse = response.GetResponseStream();
    byte[] buffer = new byte[1024];
    int read;
    while ((read = streamResponse.Read(buffer, 0, buffer.Length)) > 0){
    fs.Write(buffer, 0, read);}
    fs.Flush();fs.Close();
    }
