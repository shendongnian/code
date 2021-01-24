    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ShowCountAttribute : Attribute
    {
        public bool Required { get; set; }
        public int Order { get; set; }
    }
