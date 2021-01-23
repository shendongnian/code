    public class Foo
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int BarId { get; set; } // Add this!
        [ForeignKey(nameof(BarId))] // Add this!
        public virtual Bar Bar { get; set; }
    }
    public class Bar
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int FooId { get; set; }
        [ForeignKey(nameof(FooId))] // Add this!
        public virtual Foo Foo { get; set; }
    }
