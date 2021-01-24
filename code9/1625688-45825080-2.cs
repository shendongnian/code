    public class Person
    {
        public string Name { get; set; }
        public string URL { get; set; }
        [XmlAttribute(AttributeName = "id")]
        [JsonProperty("@id")]
        public string Id { get; set; }
    }
    public class Root
    {
        [XmlElement]
        public List<Person> Person { get; set; }
    }
