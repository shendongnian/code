    [System.Serializable, XmlType( "object")]
    public class AchivmentModel
    {
        // serialize attribute on the XmlNode
        [XmlAttribute("ID")]
        public int ID { get; set; }
        // serialize an element value
        [XmlElement("param1")]
        public string Progress { get; set; }
        // other properties omitted
    }
