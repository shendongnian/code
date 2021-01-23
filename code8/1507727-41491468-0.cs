    [XmlRoot("row")]
    public class RowDto
    {
        [XmlElement("cell")]
        public List<Cell> Cells { get; set; }
    }
    
    public class Cell
    {
        [XmlAttribute("cellType")]
        public string Type { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
