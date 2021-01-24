    [XmlRoot(ElementName = "RCMR_IN000030UV01", Namespace = "urn:hl7-org:v3")]
    public partial class RCMR_IN000030UV01
    {
        // The initially auto-generated code
        [XmlAttribute(AttributeName = "ITSVersion")]
        public string ITSVersion { get; set; }
    }
    public partial class RCMR_IN000030UV01
    {
        // The added property
        [System.Xml.Serialization.XmlElementAttribute("distributionStatus", Namespace = "urn:bccdx.ca", IsNullable = false)]
        public BCCDXDistributionStatus distStatus { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "BCCDX.DistributionStatus", Namespace = "urn:bccdx.ca")]
    public partial class BCCDXDistributionStatus
    {
        [System.Xml.Serialization.XmlElementAttribute("receivedTime", Namespace = "urn:bccdx.ca", IsNullable = false)]
        public TS receivedTime { get; set; }
    }
    public class TS
    {
        [XmlAttribute("value")]
        public DateTime Value { get; set; }
    }
