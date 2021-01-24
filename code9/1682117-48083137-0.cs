    void Main()
    {
    	var obj1 = new Person()
    	{
    		Name = "Eric",
    		Addresses = new List<Address>()
    				{
    					new Address() {Address1 = "123 First Street"}
    				}
    	};
    	
    	var index = 0;
    	
    	var addressList = typeof(Person)
    			 .GetProperty("Addresses")
    			 .GetValue(obj1);
    	var address = addressList.GetType()
    	 		 .GetProperty("Item")
    	 		 .GetValue(addressList, new object[]{index});
    	address.GetType()
    	         .GetProperty("Address1")
     	         .SetValue(address,"321 Fake Street");
    	 
    	Console.WriteLine(obj1.Addresses[index].Address1); // Outputs 321 Fake Street
    }
    
    // Define other methods and classes here
    public class Person
    {
    	public string Name { get; set; }
    	public IList<Address> Addresses { get; set; }
    }
    
    public class Address
    {
    	public string Address1 { get; set; }
    }
