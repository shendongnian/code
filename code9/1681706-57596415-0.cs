c#
static void Main(string[] args)
{
  using (var context = new OwnedEntityContext())
  {
    context.Add(new DetailedOrder
    {
      Status = OrderStatus.Pending,
      OrderDetails = new OrderDetails
      {
        ShippingAddress = new StreetAddress
        {
          City = "London",
          Street = "221 B Baker St"
        }
        //testing 3.0: "Yes, all dependents are now optional"
        //reference: https://github.com/aspnet/EntityFrameworkCore/issues/9005#issuecomment-477741082
        //NULL Owned Type Testing
        //BillingAddress = new StreetAddress
        //{
        //    City = "New York",
        //    Street = "11 Wall Street"
        //}
      }
    });
    context.SaveChanges();
  }
  //read test
  using (var context = new OwnedEntityContext())
  {
    #region DetailedOrderQuery
    var order = context.DetailedOrders.First(o => o.Status == OrderStatus.Pending);
    Console.Write("NULL Owned Type Test, Is Billing Address NULL?");
    //PRINTS FALSE
    Console.WriteLine($"{order.OrderDetails.BillingAddress == null}");
    #endregion
  }
}
c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	#region OwnsOneNested
	modelBuilder.Entity<DetailedOrder>().OwnsOne(p => p.OrderDetails, od =>
	{
		od.OwnsOne(c => c.BillingAddress);
		od.OwnsOne(c => c.ShippingAddress);
	});
	#endregion
	#region OwnsOneTable
	modelBuilder.Entity<DetailedOrder>().OwnsOne(p => p.OrderDetails, od =>
	{
		od.OwnsOne(c => c.BillingAddress);
		od.OwnsOne(c => c.ShippingAddress);
		od.ToTable("OrderDetails");
		//Exception message:Microsoft.Data.SqlClient.SqlException:
		//'Cascading foreign key 'FK_OrderDetails_DetailedOrders_OrderId' cannot
		//be created where the referencing column 'OrderDetails.OrderId' is an identity column.
		//Could not create constraint or index. See previous errors.'
		//3.0 bug: https://github.com/aspnet/EntityFrameworkCore/issues/17448#issuecomment-525444101 
		//fixed in 3.1: https://github.com/aspnet/EntityFrameworkCore/pull/17458
		od.Property("OrderId")
			.ValueGeneratedNever();
	});
	#endregion
}
  [1]: https://github.com/aspnet/EntityFrameworkCore/issues/9005#issuecomment-477741082
  [2]: https://github.com/spottedmahn/EntityFramework.Docs/tree/null-owned-type-3.0/samples/core/Modeling/OwnedEntities
