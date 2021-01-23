	public partial class BaseContext : DbContext
	{
		protected virtual DbSet<Customer> Customers { get { return this.Set<Customer>(); } }
		protected virtual DbSet<Contact> Contacts { get { return this.Set<Contact>(); } }
    }
