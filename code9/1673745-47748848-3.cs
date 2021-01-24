    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }                
        [InverseProperty("Policy")]
        public virtual PayPlan PaymentPlan { get; set; }
    }
    public class PayPlan
    {
        [Key, ForeignKey("Policy")]
        public int PolicyId { get; set; }        
        public Policy Policy { get; set; }
        public string Description { get; set; }
    }
