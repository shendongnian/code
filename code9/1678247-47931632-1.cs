    public class SomeAttribute : Attribute
    {
        public SomeAttribute() { }
        public SomeAttribute(string category, string description)
        {
            Category = category;
            Description = description;
        }
        public string Category { get; set; }
        public string Description { get; set; }
    }
