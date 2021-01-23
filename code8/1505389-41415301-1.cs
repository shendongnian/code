    [ComplexType] // optional
    public class Address
    {
    	[Required]
    	public string City { get; private set; }
    
    	[Required]
    	public string Country { get; private set; }
    
    	[Required, StringLength(10, MinimumLength = 5)]
    	public string PostalCode { get; private set; }
    
    	[Required, StringLength(2, MinimumLength = 2)]
    	public string State { get; private set; }
    
    	[Required]
    	public string StreetAddress { get; private set; }
    
    	public string UnitNumber { get; private set; }
    
    	// ...
    }
