	void Main()
	{
		List<GroceryItem> invoiceArray = new List<GroceryItem>()
		{
			new FreshItem() { Name = "Rump Steak", Price = 11.99m, Weight = 0.8 },
			new PurchasedItem() { Name = "Cream", Price = 2.2m, Quantity = 1, Weight = 0.6 },
		};
	
		foreach (GroceryItem checkoutItem in invoiceArray)
		{
			if (checkoutItem is PurchasedItem purchasedItem)
			{
				Console.WriteLine($"Condition: {checkoutItem.Condition}; Quantity: {purchasedItem.Quantity}; Weight: {checkoutItem.Weight}kg");
			}
			else
			{
				Console.WriteLine($"Condition: {checkoutItem.Condition}; Weight: {checkoutItem.Weight}kg");
			}
		}
	
		Console.ReadLine();
	}
	
	public abstract class GroceryItem
	{
		public string Name { get; set; }
		public abstract string Condition { get; }
		public double Weight { get; set; }
		public decimal Price { get; set; }
	
		public GroceryItem() { }
	
		public GroceryItem(string name, decimal price)
		{
			this.Name = name;
			this.Price = price;
		}
	
		public abstract decimal FindCost();
	}
	
	public class PurchasedItem : GroceryItem
	{
		public int Quantity { get; set; }
	
		public override string Condition { get { return "Regular"; } }
	
		public override decimal FindCost()
		{
			decimal cost = Quantity * Price * 1.1m; //1.1m is GST
			return cost;
		}
	}
	
	public class FreshItem : GroceryItem
	{
		public override string Condition { get { return "Fresh"; } }
	
		public override decimal FindCost()
		{
			decimal cost = (decimal)Weight * Price;
			return cost;
		}
	}
