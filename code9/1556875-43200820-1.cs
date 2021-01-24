     [XmlRoot(ElementName = "affdatalist")]
        public class Affdatalist
        {
            [XmlElement(ElementName = "object1")]
            public string Object1 { get; set; }
            [XmlElement(ElementName = "object2")]
            public string Object2 { get; set; }
            [XmlElement(ElementName = "object3")]
            public string Object3 { get; set; }
        }
    
        [XmlRoot(ElementName = "personData")]
        public class PersonData
        {
            [XmlElement(ElementName = "affdatalist")]
            public Affdatalist Affdatalist { get; set; }
            [XmlElement(ElementName = "anotherObject1")]
            public string AnotherObject1 { get; set; }
            [XmlElement(ElementName = "anotherObject2")]
            public string AnotherObject2 { get; set; }
        }
    
        [XmlRoot(ElementName = "personDatas")]
        public class PersonDatas
        {
            [XmlElement(ElementName = "personData")]
            public PersonData PersonData { get; set; }
        }
