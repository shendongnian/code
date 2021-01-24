    public class RootObject
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Element>))]
        public List<Element> Element { get; set; }
    }
    public class Element
    {
        [XmlAttribute]
        [JsonProperty("@Name")]
        public string Name { get; set; }
        [XmlElement("SubElement")]
        [JsonProperty("SubElement")]
        [JsonConverter(typeof(SingleOrArrayConverter<SubElement>))]
        public List<SubElement> _subelement { get; set; }
    }
    public class SubElement
    {
        [XmlElement("Color")]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Color { get; set; }
        [XmlAttribute("Name")]
        [JsonProperty("@Name")]
        public string Name { get; set; }
    }
