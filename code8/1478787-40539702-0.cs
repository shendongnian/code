    public static string getFileName(string url)
    {
       HttpWebRequest req = RequestSender.SendRequest(url);
       HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
       string header_contentDisposition = resp.Headers["content-disposition"];
       string escaped_filename = new ContentDisposition(header_contentDisposition).FileName;
    
       return Uri.UnescapeDataString(escaped_filename);
    }
