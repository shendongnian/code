    request2.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    
    request2.Proxy = null;
    using (HttpWebResponse response = (HttpWebResponse)request2.GetResponse())
    {
        StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        string mem = sr.ReadToEnd();
    }
