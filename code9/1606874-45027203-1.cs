    public enum ReportType {
        [XmlEnum("0")]
        InternalErrorReport,
        [XmlEnum("1")]
        ErrorReport,
        [XmlEnum("2")]
        InternalSuccessReport
    }
    [XmlRoot(ElementName = "result")]
    public class Result {
        [XmlElement(ElementName = "reporttype")]
        public ReportType reporttype { get; set; }
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> items { get; set; }
        [XmlElement(ElementName = "error")]
        public string error { get; set; }
        [XmlRoot(ElementName = "items\\item")]
        public class Item {
            [XmlElement(ElementName = "sku")]
            public string sku { get; set; }
            [XmlElement(ElementName = "style")]
            public string style { get; set; }
            [XmlElement(ElementName = "reason")]
            public string reason { get; set; }
        }
    }
