        public class Things
        {
            [XmlElement(Type = typeof(string)),
            XmlElement(Type = typeof(int))]
            public List<object> StringsAndInts { get; set; }
        }
