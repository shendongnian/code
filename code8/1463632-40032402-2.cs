    // covers all kind of things
    public class Measurement
    {
        [XmlAttribute("id")]
        public string Id {get;set;}
        [XmlAttribute("unit")]
        public string Unit {get;set;}
        [XmlAttribute("deg")]
        public double Deg {get;set;}
        [XmlAttribute("value")]
        public double Value {get;set;}
        [XmlAttribute("mps")]
        public double Mps {get;set;}
        [XmlAttribute("percent")]
        public double Percent {get;set;}
    }
    
