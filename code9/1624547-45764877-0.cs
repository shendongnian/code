    public interface IHasSerializationSurrogate
    {
        object ToSerializationSurrogate();
    }
    public class MyClass : IHasSerializationSurrogate
    {
        public string foo;
        public string bar;
        // If you're not going to mark MyClass with data contract attributes, DataContractJsonSerializer
        // requires a default constructor.  It can be private.
        MyClass() : this("", "") { }
        public MyClass(string f, string b = "")
        {
            this.foo = f;
            this.bar = b;
        }
        public object ToSerializationSurrogate()
        {
            if (string.IsNullOrEmpty(bar))
                return foo;
            return this;
        }
    }
