        public class test
        {
            [XmlElement(Namespace = "http://my.namespace.com/bar")]
            public string raz { get; set; }
            [XmlElement(Namespace = "http://my.namespace.com/bar")]
            public string dwa { get; set; }
        }
    
        public class Osoba
        {
            [XmlElement(Namespace = "http://my.namespace.com/foo")]
            public test tehe { get; set; }
        }
