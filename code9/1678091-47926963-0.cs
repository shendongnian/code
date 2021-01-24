    [XmlRoot("REPORTLIST")]
    public class ReportList
    {
        [XmlElement("ROW")]
        public List<Row> Rows { get; } = new List<Row>();
    
    }
    public class Row
    {
        [XmlElement("INSTNUMBER")]
        public string InstNumber { get; set; }
        [XmlElement("MATERIAL")]
        public string Material { get; set; }
    }
