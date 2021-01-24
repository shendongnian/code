    public class Foo
    { 
        [ForeignKey("B")]
        public int c { get; set; }
        public virtual B B { get; set; }
    }
