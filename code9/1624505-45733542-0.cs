    public class ArrayOfAbstractData
    {
        [XmlElement("AbstractData")]
        public AbstractData[] AbstractData { get; set; }
    }
    [XmlInclude(typeof(Test1Data))]
    [XmlInclude(typeof(Test2Data))]
    [XmlInclude(typeof(Test3Data))]
    public class AbstractData
    {
        public bool Enable { get; set; }
        public byte Id { get; set; }
        public byte Count { get; set; }
        public bool Debug { get; set; }
        public bool Error { get; set; }
        public string Info { get; set; }
    }
    public class Test1Data : AbstractData
    {
        public string Foo { get; set; }
    }
    public class Test2Data : AbstractData
    {
        public string Bar { get; set; }
    }
    public class Test3Data : AbstractData
    {
        public string Baz { get; set; }
    }
