    public class Foo
    {
        public int Id { get; set; }
    
        public string  Name { get; set; }
    
        public virtual Bar Bar { get; set; }
    }
    
    
    public class Bar
    {
        
        [Key, ForeignKey("Foo")]
        public override int Id {get;set;}
    
        public string Name { get; set; }
    
        public virtual Foo Foo { get; set; }
    }
