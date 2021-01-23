    [Serializable]
    public class UserItem
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("age")]
        public string Age { get; set; }
    
        [XmlElement("Addresses")]
        public AddressWrapper Addresses { get; set; }
    }
    
    [Serializable]
    public class AddressWrapper
    {
        [XmlElement("Address")]
        public List<AddressItem> Addresses { get; set; }
    }
