    public class Policy
    {
    	public int PolicyId { get; set; }
    
    	public string Description { get; set; }
    
    	public PayPlan PaymentPlan { get; set; }
    }
    
    public class PayPlan
    {
    	public int PayPlanId { get; set; }
    	public string Description { get; set; }
    
    	public Policy Policy { get; set; }
    	public int? PolicyId { get; set; }
    }
