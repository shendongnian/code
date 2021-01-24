    public abstract class StringElementBase
    {
        protected StringElementBase() { }
        public StringElementBase(string value) { this.Text = value; }
        [XmlText]
        public string Text { get; set; }
        public static implicit operator string(StringElementBase element)
        {
            return element == null ? null : element.Text;
        }
    }
    public sealed class A : StringElementBase
    {
        A() : base() { }
        public A(string value) : base(value) { }
    }
    public sealed class B : StringElementBase
    {
        B() : base() { }
        public B(string value) : base(value) { }
    }
    [XmlRoot(ElementName = "test")]
    public class Test
    {
        [XmlElement("a", Type = typeof(A))]
        [XmlElement("b", Type = typeof(B))]
        public List<StringElementBase> Items { get; } = new List<StringElementBase>();
        [XmlIgnore]
        // For convenience, enumerate through the string values of the items.
        public IEnumerable<string> ItemValues { get { return Items.Select(i => (string)i); } }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
