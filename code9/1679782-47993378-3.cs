	void Main()
	{
		using (var context = new YourContext())
		{
			var query = from item in context.Items
						from supplier in item.Suppliers
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
	
		public YourContext() : base("MyDb")
		{
		}
	
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Item>()
				.HasMany(item => item.Suppliers)
				.WithMany(supplier => supplier.Items)
				.Map(m =>
				{
					m.MapLeftKey("ItemSub_ID");
					m.MapRightKey("SupplierJunc_ID");
					m.ToTable("Supp_Company");
				});
		}
	}
	
	public class Item
	{
		public int ItemId { get; set; }
		public string Name { get; set; }
		public ICollection<Supplier> Suppliers { get; set; }
	}
	
	public class Supplier
	{
		public int SupplierId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Zip { get; set; }
		public ICollection<Item> Items { get; set; }
	}
	
