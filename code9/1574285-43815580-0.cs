    //Request HTTP GET
    
    ServicePointManager.Expect100Continue = false;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Proxy = null;
    request.Method = "GET";
    
    WebResponse response;
    string html = "";
    
    response = request.GetResponse();
    StreamReader sr = new StreamReader(response.GetResponseStream());
    html = sr.ReadToEnd();
    sr.Close();
    response.Close();
