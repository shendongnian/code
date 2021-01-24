    public class Foo
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
    }
    
    public class ExtraFoo : Foo
    {
        public string Extra { get; set; }
    }
