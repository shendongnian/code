    [XmlType]
    public class UserID
    {
        [XmlElement(Namespace = "NAMESPACE_3")]
        public string ID { get; set; }
    
        [XmlElement(Namespace = "NAMESPACE_3", Name = "type")]
        public int Type { get; set; }
    }
