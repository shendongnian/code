    public class ClassA
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ClassB> Types { get; set; }
    }
    public class ClassB
    {
        public string Type { get; set; }
        public int Count { get; set; }
    }
