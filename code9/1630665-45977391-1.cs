    var client = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://yiimp.ccminer.org/api/wallet?address=DshDF3zmCX9PUhafTAzxyQidwgdfLYJkBrd"));
    client.AutomaticDecompression = DecompressionMethods.GZip;
    client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
    client.Host = "yiimp.ccminer.org";
    client.KeepAlive = true;
    
    using (var s = client.GetResponse().GetResponseStream())
    using (var sw = new StreamReader(s))
    {
                    
        var ss = sw.ReadToEnd();
        Console.WriteLine(ss);
    }
