    public class Header
    {
        [XmlElement("H_DATA1")]
        public H_DATA1 HData1 { get; set; }
    ....
    }
    public class H_DATA1 {
	    [XmlElement("NAME")]
	    public String Name { get; {set; }
    }
