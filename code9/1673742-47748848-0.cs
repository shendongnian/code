    public class Policy {
        [Key]
        public int PolicyId { get; set; }
        public virtual PayPlan PaymentPlan { get; set; }
    }
    public class PayPlan {
        [Key]
        public int PayPlanId { get; set; }
        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public string Description { get; set; }
    }
