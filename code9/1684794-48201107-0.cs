    public class Tags
    {
        public string displayName { get; set; }
        public string containerregistry { get; set; }
    }
    public class Resources
    {
        public string resourceUri { get; set; }
        public string location { get; set; }
        public Tags tags { get; set; }
    }
    public class Foo
    {
        public Resources Resources { get; set; }
    }
    public class Example
    {
        public Foo foo { get; set; }
    }
