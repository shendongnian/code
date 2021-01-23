	[Table("Order_Line", Schema = "dbo")]
	public class OrderLine
	{
		[Key]
		[Column("ItemNo")]
		public string Id { get; set; }
		(many other properties here...)
		[Column("Qty")]
		public int Quantity { get; set; }
		[Column("Price")]
		public decimal Price { get; set; }
		public decimal Total { get { return Quantity * Price; } }
	}
