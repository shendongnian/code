    public class Policy {
        [Key]
        public int PolicyId { get; set; }
        // this attribute is not required, but I prefer to be specific
        // this attribute means navigation property PaymentPlan
        // is "anoter end" of navigation property PayPlan.Policy
        [InverseProperty("Policy")]
        public virtual PayPlan PaymentPlan { get; set; }
    }
    public class PayPlan {
        [Key]
        public int PayPlanId { get; set; }
        // define foreign key explicitly here
        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
        public string Description { get; set; }
    }
