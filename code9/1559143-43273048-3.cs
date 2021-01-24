    [XmlRoot("Test")]
    public class DtoRoot {
        [XmlArray("Testdata")]
        [XmlArrayItem("abc")]
        public List<KeyValuePair> Items {get;} = new List<KeyValuePair>();
        public string this[string key] => Items.FirstOrDefault(x => x.Key == key)?.Value;
    }
    public class KeyValuePair{
        [XmlAttribute("name")]
        public string Key {get;set;}
        [XmlText]
        public string Value {get;set;}
    }
