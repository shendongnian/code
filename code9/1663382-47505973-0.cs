    var waiting = new Stopwatch();
    var contentDownload = new Stopwatch();
    waiting.Start();
    using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
    {
        waiting.Stop();
        contentDownload.Start();
        using (var reader = new StreamReader(webResponse.GetResponseStream()))
        {
            var body = reader.ReadToEnd();
            contentDownload.Stop();
        }
    }
