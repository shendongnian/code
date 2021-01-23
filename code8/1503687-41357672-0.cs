    public string GetResponseText(string userAgent) {
      string url = "http://a.com/?id=5";
      string responseText = String.Empty;
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.Method = "GET";
      request.UserAgent = userAgent;
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
           responseText = sr.ReadToEnd();
        }
     return responseText;
    }
