    [XmlRoot(ElementName = "A")]
        public class A
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            private List<B> b = new List<B>();
    
            [XmlElement("B")]
            public List<B> B
            {
                get { return b; }
                set { b = value; }
            }
        }
    
        public class B
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            private List<C> c = new List<C>();
    
            [XmlElement("C")]
            public List<C> C
            {
                get { return c; }
                set { c = value; }
            }
        }
    
        public class C
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            private List<B> b = new List<B>();
    
            [XmlElement("B")]
            public List<B> B
            {
                get { return b; }
                set { b = value; }
            }
        }
