    public class ItemRental
    {
    	// ...
    	[ForeignKey("OriginatingSalesOrderId")]
    	[InverseProperty("Rentals")]
    	public SalesOrder OriginatingSalesOrder { get; set; } 
    	// ...    
    	[ForeignKey("DepositCreditedOnSalesOrderId")]
    	[InverseProperty("Refunds")]
    	public SalesOrder DepositCreditedOnSalesOrder { get; set; }
    }
