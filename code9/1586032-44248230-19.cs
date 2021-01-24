	void Main()
	{
		var suppliers = new List<Supplier>()
		{
			new Supplier() { Id = 1, Country = "USA" },
			new Supplier() { Id = 2, Country = "Japan" },
		};
		
		var customers = new List<Customer>()
		{
			new Customer() { Id = 10, Country = "USA" },
			new Customer() { Id = 11, Country = "USA" },
			new Customer() { Id = 20, Country = "Japan" },
			new Customer() { Id = 21, Country = "Japan" },
		};
		
        // Solution: 
        // Lambda-styled LINQ query to merge the two types
		List<SupplierCustomer> supplierCustomers = suppliers.Join(
			customers,
			supplier => supplier.Country, // primary key
			customer => customer.Country, // foreign key
			(supplier, customer) => new SupplierCustomer
			{
				Supplier = supplier,
				Customer = customer
			}).ToList();
        // Read up about Enumerations and the issues with doing a ToList() early.
        // You should avoid doing this heavy call in production and
        // try and optimize the result first!
	}
