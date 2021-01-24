    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "imcwp")]
    public partial class strTrailerRequestTrailerResponseTrailer
    {
        public string TrailerId { get; set; }
    
        public string TrailerType { get; set; }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "imcwp")]
    [System.Xml.Serialization.XmlRootAttribute("strTrailerRequest-TrailerResponse", Namespace = "imcwp", IsNullable = false)]
    public partial class strTrailerRequestTrailerResponse
    {
        [System.Xml.Serialization.XmlElementAttribute("Trailer")]
        public strTrailerRequestTrailerResponseTrailer[] Trailer { get; set; }
    }
