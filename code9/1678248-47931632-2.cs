    public class BaseAttribute : Attribute
    {
        public BaseAttribute() { }
        public BaseAttribute(string defaultValue = null)
        {
            DefaultValue = defaultValue;
        }
        public string DefaultValue { get; set; }
    }
    public class SomeAttribute : BaseAttribute
    {
        public SomeAttribute() { }
        public SomeAttribute(string category, string description, string defaultValue = null)
            :base(defaultValue)
        {
            Category = category;
            Description = description;
        }
        public string Category { get; set; }
        public string Description { get; set; }
    }
