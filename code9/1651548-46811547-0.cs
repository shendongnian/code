    public partial class ORD_Garanzie
    {
        public long ID { get; set; }
    
        [Column(Order = 1)] // optional, not needed for the index
        [Index("IX_SomeIndexName_Unique", 0, IsUnique = true)]
        public int intestatario { get; set; }
    
        [Column(Order = 2)] // optional, not needed for the index
        [Index("IX_SomeIndexName_Unique", 1, IsUnique = true)]
        public string n_polizza { get; set; }
