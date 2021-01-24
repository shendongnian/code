    [XmlRoot("country")]
    public class Country
    {
        [XmlElement("city", typeof(City))]
        [XmlElement("village", typeof(Village))]
        public List<object> CitiesAndVillages { get; set; }    
    }
    
    public class City
    {
        [XmlText]
        public string Value { get; set; }
    }
    
    public class Village
    {
        [XmlText]
        public string Value { get; set; }
    }
