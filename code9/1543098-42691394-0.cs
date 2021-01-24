    public class DynamicUriParameterAttribute : Attribute
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }
    }
