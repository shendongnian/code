    public class Bar
    {
        [Key, Column("Bar_ID")]
        public int Id { get; set; }
    
        public Foo Foo { get; set; }   
    }
