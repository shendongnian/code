     public class TopupResponse
    {
        [XmlElement(Namespace = "")]
        public Result result { get; set; }
    }
    public class Result
    {
        [XmlElement(Namespace = "")]
        public string conversionRate { get; set; }
        [XmlElement(Namespace = "")]
        public string datetime { get; set; }
        [XmlElement(Namespace = "")]
        public string distAmount { get; set; }
        [XmlElement(Namespace = "")]
        public string msisdn { get; set; }
        [XmlElement(Namespace = "")]
        public string newBalance { get; set; }
        [XmlElement(Namespace = "")]
        public string operAmount { get; set; }
        [XmlElement(Namespace = "")]
        public string responseCode { get; set; }
        [XmlElement(Namespace = "")]
        public string transId { get; set; }
    }
