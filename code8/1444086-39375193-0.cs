    [XmlRoot("yourRootName")]
    public class Foo {
        [XmlElement("itemOne")] public string A {get;set;}
        [XmlElement("itemTwo")] public string B {get;set;}
        [XmlArray("listOfItems")]
        [XmlArrayItem("listItem")]
        public List<Bar> Bars {get;set;}
    }
    public class Bar {
        [XmlElement("partOne")] public int C {get;set;}
        [XmlElement("partTwo")] public string D {get;set;}
    }
