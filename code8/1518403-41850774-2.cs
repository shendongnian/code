    public class Transaction
    {
        [Column(Order = 0), Key]
        public int FromID { get; set; }
    
        [Column(Order = 1), Key]
        public int ToID { get; set; }
    
        public float Amount { get; set; }
    
        [ForeignKey("FromID")]
        public virtual Account From { get; set; }
        
        [ForeignKey("ToID")]
        public virtual Account To { get; set; }
    }
