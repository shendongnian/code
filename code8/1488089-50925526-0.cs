    var hRequest = WebRequest.CreateHttp("/*Rand Code Url*/?rnd=" + new Random().NextDouble());
    hRequest.Accept = "image/png, image/svg+xml, image/jxr, image/*; q=0.8, */*; q=0.5";
    hRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
    hRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, /*Page AcceptLanguage*/);
    hRequest.KeepAlive = true;
    string cookie = "";
    webBrowser.Invoke((MethodInvoker)delegate { cookie = webBrowser.Document.Cookie; });
    hRequest.Headers.Add(HttpRequestHeader.Cookie, cookie);
    hRequest.Headers.Add("DNT", "1");
    hRequest.Host = /*page window.location.host*/;
    hRequest.Referer = /*page.referer*/;
    hRequest.UserAgent = /*page navigator.userAgent*/;
    hRequest.Method = "GET";
    var hResponse = hRequest.GetResponse();
    var response = hResponse.GetResponseStream();
    List<byte> data = new List<byte>();
    //read stream
    while (true)
    {
        int i = response.ReadByte();
        if (i >= 0)
            data.Add((byte)i);
        else
            break;
    }
    if (data.Count == 0) return "";//if not succes, return empty string
    //convert to Base64 string
    string RandBase64 = Convert.ToBase64String(data.ToArray());
    hResponse.Dispose();
