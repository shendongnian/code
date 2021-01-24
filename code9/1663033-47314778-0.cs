    public class Source
    {
        public int Id { get; set; }
    }
    public class Dest
    {
        public int Id { get; set; }
        public List<Foo> Foos { get; set; }
    }
    public class Foo
    {
        public string Name { get; set; }
    }
