    public class JsonRoot
    {
        public string Filename { get; set; }
        public Info Info { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public class Info
    {
        public Title title { get; set; }
        public Description description { get; set; }
    }
    public class Title
    {
        public string Name { get; set; }
        public string[] Values { get; set; }
        public object[] NumericValues { get; set; }
        public object[] DateTimeValues { get; set; }
        public object[] LinkedComponentValues { get; set; }
        public int FieldType { get; set; }
    }
    public class Description
    {
        public string Name { get; set; }
        public string[] Values { get; set; }
        public object[] NumericValues { get; set; }
        public object[] DateTimeValues { get; set; }
        public object[] LinkedComponentValues { get; set; }
        public int FieldType { get; set; }
    }
