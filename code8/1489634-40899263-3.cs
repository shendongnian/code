    [XmlRoot("InterestRates")]
    public class InterestRates
    {
        [XmlArray("InterestRates_A")]
        [XmlArrayItem("InterestRate_A")]
        public InterestRate [] InterestRates_A { get; set; }
        [XmlArray("InterestRates_B")]
        [XmlArrayItem("InterestRate_B")]
        public InterestRate [] InterestRates_B { get; set; }
        [XmlArray("InterestRates_C")]
        [XmlArrayItem("InterestRate_C")]
        public InterestRate [] InterestRates_C { get; set; }
        [XmlArray("InterestRates_D")]
        [XmlArrayItem("InterestRate_D")]
        public InterestRate [] InterestRates_D { get; set; }
        [XmlArray("InterestRates_E")]
        [XmlArrayItem("InterestRate_E")]
        public InterestRate [] InterestRates_E { get; set; }
        [XmlArray("InterestRates_F")]
        [XmlArrayItem("InterestRate_F")]
        public InterestRate [] InterestRates_F { get; set; }
    }
    public class InterestRate
    {
        [XmlElement("ValidFrom")]
        public string ValidFrom { get; set; }
        [XmlElement("ValidTo")]
        public string ValidTo { get; set; }
        [XmlElement("Rate")]
        public string Rate { get; set; }
        [XmlElement("Rate2")]
        public string Rate2 { get; set; }
    }
