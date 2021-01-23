    var req = (HttpWebRequest) WebRequest.Create("http://stackoverflow.com");
    req.Method = "GET";
    req.UserAgent = "MyCrawler/1.0";
    req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    var resp = (HttpWebResponse)req.GetResponse();
                   
    // is this even html and not an image, or video       
    if (resp.ContentType.Contains("text/html"))
    {
        var sb = new StringBuilder();
        var buffer = new char[8192];
        using (var stream = resp.GetResponseStream())
        using (var sr = new StreamReader(stream, Encoding.UTF8))
        {
            var read = sr.ReadBlock(buffer, 0, buffer.Length);
            while(read > 0)
            {
                sb.Append(buffer);
                // max allowed chars per source
                if (sb.Length > 50000)
                {
                    sb.Append(" ... source truncated due to size");
                    break;
                }
                read = sr.ReadBlock(buffer, 0, buffer.Length);
            }
            // pageSource will hold the html now
            var pageSource = sb.ToString();
        }
    }
