    [XmlRoot("response")]
    public class SummaryAccountBalanceResponse
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("accountbalance")]
        public SummaryAccountBalance Balance { get; set; }
    }
