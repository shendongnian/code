    [XmlRoot("ArrayOfEducation", Namespace = "http://schemas.datacontract.org/2004/07/CovUni.Domain.Admissions")]
    public class ArrayOfEducation
    {
        [XmlElement("Education")]
        public List<ContainerEducation> education { get; set; }
    }
    public class ContainerEducation
    {
        [XmlElement(ElementName = "_apCode")]
        public int _apCode { get; set; }
        [XmlElement(ElementName = "_educationId")]
        public int _educationId { get; set; }
        [XmlElement(ElementName = "_establishmentDetails")]
        public string _establishmentDetails { get; set; }
        [XmlElement(ElementName = "_ucasSchoolCode")]
        public string _ucasSchoolCode { get; set; }
        [XmlElement(ElementName = "_fromDate")]
        public DateTime? _fromDate { get; set; }
        [XmlElement(ElementName = "_toDate")]
        public DateTime? _toDate { get; set; }
        [XmlElement(ElementName = "_attendanceType")]
        public string _attendanceType { get; set; }
        [XmlElement(ElementName = "_auditList", Namespace = "http://schemas.datacontract.org/2004/07/CovUni.Common.Base")]
        public string _auditList { get; set; }
    }
