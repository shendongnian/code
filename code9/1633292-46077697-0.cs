    public partial class OrderLine : Base
    {
    
        [Key]
        public int OrderLineId { get; set; }
    
        public virtual AccountTransaction AccountTransaction { get; set; }
    }
    
    public class AccountTransaction
    {
        [Key]
        public int TransactionId { get; set; }
    
        public int? OrderLineId { get; set; }
    
        [ForeignKey("OrderLineId")]
        public virtual OrderLine OrderLine { get; set; }        
    }
