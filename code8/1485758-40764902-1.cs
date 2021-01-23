    var customers = new TestAsyncEnumerable<Customer>(new List<Customer>
    {
    	new Customer
    	{
    		Id = new Guid("d4e749ba-6874-40f4-9134-6c9cc1bc95fe"),
    		Name = "John Doe",
    		Age = 18,
    		Organization = new Organization
    		{
    			Id = new Guid("b2ba06c9-5c00-4634-b6f7-80167ea8c3f1"),
    			Name = "TheCompany",
    			Number = 42
    		}
    	},
    	new Customer
    	{
    		Id = new Guid("0679ceb5-3d4f-41f3-a1b0-b167e1ac6d7e"),
    		Name = "Another Guy",
    		Age = 39,
    		Organization = new Organization
    		{
    			Id = new Guid("b2ba06c9-5c00-4634-b6f7-80167ea8c3f1"),
    			Name = "TheCompany",
    			Number = 42
    		}
    	}
    }.AsQueryable();
