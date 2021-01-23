    public class SomeModel
    {
        [XmlElement("CustomerName")]
        public string CustomerName { get; set; }
        [XmlText]
        public string CustomerAgeString { get { return CustomerAge.ToString(); } set { throw new NotSupportedException("Setting the CustomerAgeString property is not supported"); } }
        [XmlIgnore]
        public string CustomerAge { get; set; }
    }
