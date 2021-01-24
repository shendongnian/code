    [XmlRoot("Accounts")]
    public class Accounts
    {
        [XmlElement(ElementName = "Number")]
        public AccountNumber[] AccountNumbers;
    }
