    public class Metadata
    {
        public string uri { get; set; }
        public string etag { get; set; }
        public string type { get; set; }
        public string edit_media { get; set; }
        public string media_src { get; set; }
        public string content_type { get; set; }
        public string media_etag { get; set; }
    }
    
    public class D
    {
        public Metadata __metadata { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Path { get; set; }
    }
    
    public class RootObject
    {
        public List<D> d { get; set; }
    }
