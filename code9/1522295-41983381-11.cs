    [XmlRoot()] public class Brand {
        [XmlAttribute()] public string Name { get; set; }
    }
    [XmlRoot()] public class Menu {
        [XmlElement()] public List<Brand> Brands { get; set; }
    }
