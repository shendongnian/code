    internal class ProductMetadata
    {
    	[Key]
    	public int Id { get; set; }
    
    	[Required]
    	[Display(Name = "SomeName")]
    	public string ProductName { get; set; }
    
    	public int OrderId { get; set; }
    
    	public Order Order { get; set; }
    }
