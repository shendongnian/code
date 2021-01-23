    [XmlRoot("Gender")]
    public class Gender
    {
        [XmlElement("Gender")]
        public List<GenderListWrap> _GenderListWrap = new List<GenderListWrap>();       
    }
   
    public class GenderListWrap
    {
        [XmlAttribute("list")]
        public string _ListTag { get; set; }
        [XmlElement("Item")]
        public List<Item> _GenderList = new List<Item>();
    }
    public class Item
    {
        [XmlElement("CODE")]
        public string Code { get; set; }
        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }
    }
