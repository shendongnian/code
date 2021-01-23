    [XmlArray("urlset"), XmlArrayItem("url")]
    public class url
    {
        public string loc { get; set; }
        public DateTime lastmod { get; set; }        
        public double priority { get; set; }
    }
