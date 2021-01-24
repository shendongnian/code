    [XmlRoot(ElementName = "Sample")]
    public class Sample
    {
        [XmlElement(ElementName = "SampleID")]
        public string SampleID { get; set; }
    
        [XmlElement(ElementName = "SamplePC")]
        public string SamplePC { get; set; }
    
        [XmlElement(ElementName = "antennaName")]
        public string AntennaName { get; set; }
    
        [XmlElement(ElementName = "channel")]
        public string Channel { get; set; }
    
        [XmlElement(ElementName = "power")]
        public string Power { get; set; }
    
        [XmlElement(ElementName = "polarization")]
        public string Polarization { get; set; }
    
        [XmlElement(ElementName = "inventoried")]
        public string Inventoried { get; set; }
    }
    
    
    [XmlRoot(ElementName = "readSampleIDs")]
    public class ReadSampleIDs
    {
        [XmlArray(ElementName = "returnValue")]
        [XmlArrayItem(ElementName = "Sample")]
        public List<Sample> Sample { get; set; }
    }
    
    [XmlRoot(ElementName = "reply", Namespace = "http://www.cpandl.com")]
    public class Reply
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
    
        [XmlElement(ElementName = "resultCode")]
        public string ResultCode { get; set; }
    
        [XmlElement(ElementName = "readSampleIDs")]
        public ReadSampleIDs ReadSampleIDs { get; set; }
    }
