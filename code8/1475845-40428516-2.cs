    [XmlRoot("data", Namespace = "urn:schemas-microsoft-com:rowset")]
    public class Data
    {
        [XmlElement("row", Namespace = "#RowsetSchema")]
        public List<ItemList> Rows { get; set; }
    }
    public class ItemList
    {
        [XmlAttribute("ows_h_id")]
        public int Hid {get; set; }
        [XmlAttribute("ows_Status")]
        public string Status {get; set; }
        [XmlAttribute("ows_Report_x0020_Type")]
        public string Type {get; set; }
    }
