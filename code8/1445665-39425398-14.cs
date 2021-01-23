    public class SomeClass : ISomeInterface
    {
        public string Value { get; set; }
        public override string ToString() => string.Format("ToString() : {0}",Value);
    }
