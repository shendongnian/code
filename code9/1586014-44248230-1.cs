	class Supplier
	{
		public int Id { get; set; }
		public string Country { get; set; }
	}
	
	class Customer
	{
		public int Id { get; set; }
		public string Country { get; set; }
	}
	
	class SupplierCustomer
	{
		public Supplier Supplier { get; set; }
		public Customer Customer { get; set; }
	}
	
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
		
		List<SupplierCustomer> supplierCustomers = suppliers.Join(
			customers,
			supplier => supplier.Country,
			customer => customer.Country,
			(supplier, customer) => new SupplierCustomer
			{
				Supplier = supplier,
				Customer = customer
			}).ToList();
	}
