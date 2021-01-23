    public class CreditCard 
    {
        public int Id { get; set; }
         
        [StringLength(128)]
        public string UserName { get; set; }
    
        [Range(16, 16)]
        [Column(TypeName = "CHAR")]
        public string CardNumber { get; set; }
    
        [Column(TypeName = "DATE")]
        public DateTime ExpirationDate { get; set; }
    
        [Range(3, 3)]
        [Column(TypeName = "CHAR")]
        public string CVV { get; set; }
    }
