    [XmlRoot("response")]
    public class SummaryAccountBalanceResponse
    {
        [XmlElement("accountbalance")]
        public SummaryAccountBalance Balance { get; set; }
    }
