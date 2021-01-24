    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    
        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Valuation> Valuations { get; set; }
    }
    
    public class Valuation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        [ForeignKey(typeof(Stock))]     // Specify the foreign key
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    
        [ManyToOne]      // Many to one relationship with Stock
        public Stock Stock { get; set; }
    }
