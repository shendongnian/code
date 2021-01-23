    [XmlRoot(ElementName = "Gender")]
    public class Genders
    {
        [XmlElement(ElementName = "Gender")]
        public Gender gender { get; set; }
    }
    public class Gender
    {
        [XmlElement(ElementName = "Item")]
        public List<Item> GenderList = new List<Item>();
    }
    public class Item
    {
        [XmlElement("CODE")]
        public string Code { get; set; }
        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }
    }
