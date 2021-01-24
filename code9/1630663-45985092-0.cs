    public static string GetAccessToken(string clientId, string secret, string AUTHORIZATION_CODE, string redirect_uri)
    {
      try
      {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.universe.com/oauth/token");
        webRequest.Method = "POST";
        webRequest.Accept = "application/json";
        webRequest.ContentType = "application/x-www-form-urlencoded";
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(string.Format("grant_type=authorization_code&client_id={0}&client_secret={1}&code={2}&redirect_uri={3}", clientId, secret, AUTHORIZATION_CODE, redirect_uri));
        webRequest.ContentLength = buffer.Length;
        using (var reqStrm = webRequest.GetRequestStream())
        {
         reqStrm.Write(buffer, 0, buffer.Length);
        }
        using (HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse())
        {
            using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
            {
             return reader.ReadToEnd();
            }
        }
      }
      catch (Exception ex){return ex.Message;}
    }
