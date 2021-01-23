    public class SimpleClass
    {
        // getter only, no setter
        public int SimpleProperty { get; }
        public SimpleClass(int simpleProperty)
        {
            // allowed in C#6+
            SimpleProperty = simpleProperty;
        }
    }
