	void Main()
	{
		using (var context = new YourContext())
		{
			var query = from item in context.Items
						join link in context.SupplierItems
							on item.ItemId equals link.ItemId
						join supplier in context.Suppliers
							on link.SupplierId equals supplier.SupplierId
						where item.ItemId == 8
						select new
						{
							Name = supplier.Name,
							Adress = supplier.Address,
							Email = supplier.Email,
							Phone = supplier.Phone,
							Zip = supplier.Zip,
						};
	
			//...
		}
	}
	
	public class YourContext : DbContext
	{
		public DbSet<Item> Items { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<SupplierItem> SupplierItems { get; set; }
	
		public YourContext() : base("MyDb")
		{
		}
	
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Item>()
				// ...
				;
	
			modelBuilder.Entity<Supplier>()
				// ...
				;
	
			modelBuilder.Entity<SupplierItem>()
				// ...
				;
		}
	}
	
	public class Item
	{
		public int ItemId { get; set; }
		public string Name { get; set; }
	}
	
	public class Supplier
	{
		public int SupplierId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Zip { get; set; }
	}
	
	public class SupplierItem
	{
		public int ItemId { get; set; }
		public int SupplierId { get; set; }
	}
