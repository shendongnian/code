    try {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.CookieContainer = new CookieContainer();
        request.UserAgent = this.UserAgent;
        request.KeepAlive = false;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) { 
            strResult = reader.ReadToEnd();
            response.Close();
    }
