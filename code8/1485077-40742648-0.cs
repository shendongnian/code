    public class FooPair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Foo Foo1 { get; set; }
        public Foo Foo2 { get; set; }
        public virtual Foo Foo { get; set; }
    }
    public class Foo
    {
        public Foo()
        {
            FooPairs = new List<FooPair>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FooPairId { get; set; }
        [ForeignKey("FooPairId")]
        public ICollection<FooPair> FooPairs { get; set; }
    }
