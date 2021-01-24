    public abstract class StringElementBase
    {
        public StringElementBase(string value) { this.Value = value; }
        protected StringElementBase() { }
        [XmlText]
        public string Value { get; set; }
        public static implicit operator string(StringElementBase element)
        {
            return element == null ? null : element.Value;
        }
    }
    public sealed class StringElementA : StringElementBase
    {
        StringElementA() : base() { }
        public StringElementA(string value) : base(value) { }
    }
    public sealed class StringElementB : StringElementBase
    {
        StringElementB() : base() { }
        public StringElementB(string value) : base(value) { }
    }
    // https://stackoverflow.com/questions/48096673/keep-sort-when-deserialize-and-serialize-xml-using-xmlserializer
    [XmlRoot(ElementName = "test")]
    public class Test
    {
        [XmlElement("a", Type = typeof(StringElementA))]
        [XmlElement("b", Type = typeof(StringElementB))]
        public List<StringElementBase> Items { get; set; }
        [XmlIgnore]
        // For convenience, enumerate through the string values of the items.
        public IEnumerable<string> ItemValues { get { return (Items ?? Enumerable.Empty<StringElementBase>()).Select(i => (string)i); } }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
