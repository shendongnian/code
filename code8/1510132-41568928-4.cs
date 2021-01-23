    public static string CallRestMethod(string url)
    {
        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
        webrequest.Method = "GET";
        webrequest.ContentType = "application/x-www-form-urlencoded";
        webrequest.Headers.Add("Username", "xyz");
        webrequest.Headers.Add("Password", "abc");
        HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
        Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
        StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
        string result = string.Empty;
        result = responseStream.ReadToEnd();
        webresponse.Close();
        return result;
    }
