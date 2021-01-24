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
		var suppliers = new List<Supplier>();
		var customers = new List<Customer>();
		List<SupplierCustomer> supplierCustomers = suppliers.Join(
			customers,
			supplier => supplier.Country,
			customer => customer.Country,
			(supplier, customer) => new SupplierCustomer()
			{
				Supplier = supplier,
				Customer = customer
			});
	}
