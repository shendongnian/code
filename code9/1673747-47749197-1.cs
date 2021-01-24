    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    	modelBuilder.Entity<Policy>()
    		.HasOne(a => a.PaymentPlan)
    		.WithOne(b => b.Policy)
    		.HasForeignKey<PayPlan>(b => b.PolicyId)
    		.OnDelete(DeleteBehavior.Cascade);
    }
