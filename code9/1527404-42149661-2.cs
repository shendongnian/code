    public class HosterAttribute : Attribute
    {
        public Type Type { get; set; }
        public HosterAttribute(Type type)
        {
            Type = type;
        }
    }
