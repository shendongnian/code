    private static string translate(string input, string languagePair)
    {
        string url = String.Format("https://translate.google.com/?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
        WebClient wc = new WebClient();
        wc.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; …) Gecko/20100101 Firefox/55.0");
        wc.Encoding = Encoding.UTF8;
        string result = wc.DownloadString(url);
        int start = result.IndexOf("result_box");
        string sub = result.Substring(start);
        sub = sub.Substring(0, sub.IndexOf("</span>"));
        start = sub.LastIndexOf(">");
        sub = sub.Substring(start + 1);
        return sub;
    }
