    [XmlRoot("vehicle")]
    public class Vehicle
    {
        [XmlAttribute("found")]
        public bool Found { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("buildDate")]
        public string BuildDate { get; set; }
        [XmlElement("modelYear")]
        public string ModelYear { get; set; }
        [XmlArray("optionList")]
        [XmlArrayItem("option")]
        public List<Option> OptionList { get; set; }
    }
    public class Option
    {
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlText]
        public string Description { get; set; }
    }
			
