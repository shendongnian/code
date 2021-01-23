    [XmlRoot("betterName")]
    public class Foo {
        [XmlAttribute("foo")] public string A {get;set;}
        [XmlAttribute("bar")] public string B {get;set;}
        [XmlElement("nameMe")]
        public List<Bar> Bars {get;set;}
    }
    public class Bar {
        [XmlAttribute("a")] public int C {get;set;}
        [XmlAttribute("b")] public string D {get;set;}
    }
