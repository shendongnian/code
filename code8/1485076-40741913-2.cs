    public class Foo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual FooPair FooPair { get; set; }
    }
    
    public class FooPair
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }   
       public virtual ICollection<Foo> Foos { get; set; }
       public Foo()
        {
            Foos = new List<Foo>();
        }
    }
