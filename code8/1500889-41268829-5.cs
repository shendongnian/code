    [Serializable]
    [XmlRoot("wrapper")]
    public class StopRecord
    {
        [XmlElement("root")]
        public Root Root { get; set; }
    }
    
    public class Root
    {
        [XmlElement("stop")]
        public Stop stop { get; set; }
    }
    
    public class Stop
    {
        [XmlAttribute("recordingid")]
        public string recordingid { get; set; }
    
        [XmlAttribute("result")]
        public string result { get; set; }
    }
