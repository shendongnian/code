    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class ShowCountAttribute : System.Attribute
    {
        public int Order { get; set; }
    }
