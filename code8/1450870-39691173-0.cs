    public class Data
    {
        // It is a workaround to prevent consumer generate two dimensional array of Input (Input[][])
        // instead of creating the array of Input inside the Data.
        // This is a fake field and is not used anywhere
        [System.Xml.Serialization.XmlElement(ElementName = "reserve")]
        public string Reserve { get; set; }
        [System.Xml.Serialization.XmlElement(ElementName = "input")]
        public Input[] Input { get; set; }
    }
