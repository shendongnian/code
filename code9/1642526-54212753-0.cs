public class Customer
{
	public Guid Id { get; set; }
	public List<Order> Orders {get; set;}
}
public class Order
{
	public Guid Id { get; set; }
	
	public Guid CustomerId { get; set; }
	public Guid Customer { get; set; }
}
// AppDbContext
builder.Entity<Order>()
	 .HasOne(x => x.Customer)
	 .WithMany() //WRONG -> should be .WithMany(x => x.Orders) OR modify the model to not define the collection at the customer entity
	 .HasForeignKey(x => x.CustomerId)
	 .OnDelete(DeleteBehavior.SetNull)
;
