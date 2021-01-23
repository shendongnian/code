    [Serializable()]
    [System.Xml.Serialization.XmlRoot("PICKUPREQUESTRESPONSE")]
    public class PICKUPREQUESTRESPONSE
    {
        //[XmlArray("PICKUPREQUESTRESPONSE")]
        //[XmlArrayItem("STATUS", typeof(STATUS))]
        [XmlElement("STATUS")]
        public STATUS[] STATUS { get; set; }
    }
    
    
    [Serializable()]
    public class STATUS
    {
        [XmlElement("CODE")]
        public string CODE { get; set; }
    
        [XmlElement("VIEW")]
        public string VIEW { get; set; }
    
        [XmlElement("ERRORTYPE")]
        public string ERRORTYPE { get; set; }
    
        [XmlElement("MESSAGE")]
        public string MESSAGE { get; set; }
    
        //[XmlArrayItem("VERSION", typeof(VERSION))]
        [XmlElement("VERSION")]
        public VERSION[] VERSION { get; set; }
    
    }
    
    [Serializable()]
    public class VERSION
    {
        [System.Xml.Serialization.XmlElement("CURRENT")]
        public string CURRENT { get; set; }
    
        [System.Xml.Serialization.XmlElement("CURRENT_RELEASE_DATE")]
        public string CURRENT_RELEASE_DATE { get; set; }
        [System.Xml.Serialization.XmlElement("LATEST")]
        public string LATEST { get; set; }
    
        [System.Xml.Serialization.XmlElement("LATEST_RELEASE_DATE")]
        public string LATEST_RELEASE_DATE { get; set; }
    
    }
