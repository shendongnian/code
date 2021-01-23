    WebClient wc = new WebClient();
    wc.Headers.Add(HttpRequestHeader.Cookie, cc);
    using (Stream data = wc.OpenRead(new Uri(e.Url.ToString())))
    {
        using (Stream targetfile = File.Create(targetPath))
        {
           data.CopyTo(targetfile);
        }
    }
    
