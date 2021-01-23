      [XmlType("InterestRates_B")]
      public class InterestRates_B
      {
        [XmlArray("InterestRate_B")]
        [XmlArrayItem("InterestRate_B", typeof(InterestRate_B))]
        public InterestRate_B[] InterestRate_B { get; set; }
      }
