    using (var client = new WebClient()) 
    {
       string s = client.DownloadString(url);
       // s contains the whole document text
       int strCount = s.Length;
       int byteCount = System.Text.ASCIIEncoding.Unicode.GetByteCount(s);
    }
