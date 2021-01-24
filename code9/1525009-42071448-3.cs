    [XmlRoot]
    public class Car {
        [XmlAttribute]
        public string Model { get; set; }
        [XmlAttribute]
        public string Plate { get; set; }
        [XmlArray]
        [XmlArrayItem]
        public List<Part> Parts { get; set; }
    }
    [XmlRoot]
    public class Part {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public int Quantity { get; set; }
    }
