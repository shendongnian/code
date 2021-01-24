    [XmlRoot(ElementName = "Table")]
    public class Table
    {
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
    }
    [XmlRoot(ElementName = "NewDataSet")]
    public class NewDataSet
    {
        [XmlElement(ElementName = "Table")]
        public List<Table> Table { get; set; }
    }
