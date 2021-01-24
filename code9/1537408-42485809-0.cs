    public static IEnumarable<Order> GetLastUpdatedOrder()
	{
	//Return dictionnay here
	}
    public override int SaveChanges()
	{
		var updatedOrder = ChangeTracker.Entries<Order>().Where(o => o.State == EntityState.Modified).ToList();
		//Manage here Your dictionnary
		var i = base.SaveChanges();
		return i;
	}
