    public class AccountNumber
    {
        [XmlText]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "credit")]
        public int Credit { get; set; }
    }
