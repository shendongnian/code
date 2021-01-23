    public class Foo
    {
        public int Id { get; set; }
        public virtual FooPair FooPair { get; set; }
    }
    
    public class FooPair
    {
        [Key]
       public int Id { get; set; }
    
       public virtual ICollection<Foo> Foos { get; set; }
    }
