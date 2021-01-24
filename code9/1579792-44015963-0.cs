    public class ShippingAddresses
    {
    	public string Id { get; set; }
    	public string CustomerId { get; set; }
    	public string Address { get; set; }
    	public string Address2 { get; set; }
    	public string City { get; set; }
    	public string CountryId { get; set; }
    }
    
    List<ShippingAddresses> shippingAddresses = new List<ShippingAddresses>();
    
    //This statement will help you only get 1 row for each ID value
    shippingAddresses = shippingAddresses.GroupBy(p => p.Id).Select(p => p.First()).ToList();
