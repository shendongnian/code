    public class Foo
    {
        [Key, Column("Foo_ID")]
        public int Id { get; set; }
    
        // this can't be a single reference property unfortunately... but it will only contain 0 or 1 object when working with it.
        public ICollection<Bar> Bars { get; set; }
    }
    
    public class Bar
    {
        [Key, Column("Bar_ID")]
        public int Id { get; set; }
    
        [Index(IsUnique = true)]
        [Column("Bar_Foo_ID")]
        public int? FooId { get; set; }
    
        public Foo Foo { get; set; }   
    }
    
    modelBuilder.Entity<Foo>()
                .HasMany(a => a.Bars)
                .WithRequired(x => x.Foo)
                .HasForeignKey(x => x.FooId)
                .WillCascadeOnDelete(true);
