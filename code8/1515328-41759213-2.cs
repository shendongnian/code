    public class ZendeskFile : IHttpPostedFile
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public Stream InputStream { get; set; }
    }
