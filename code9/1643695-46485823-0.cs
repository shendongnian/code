    public class Mall
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int NumberOfShopSpaces { get; set; }
    
        List<Shop> CurrentShops { get; set; }
    }
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    
        public List<CashDesk> CashDesks { get;set; }
    }
