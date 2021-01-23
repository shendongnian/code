    public class Bar 
    {
        public Bar(int value)
        {
            Value = value;
        }
        public Bar()
        {
        }
        [XmlText]
        public int Value { get; set; }
    }
    public class Foo : List<Bar>
    {
    }
