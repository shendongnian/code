	public abstract class GroceryItem
	{
		public string Name { get; set; }
		public string Condition { get; set; }
		public decimal Price { get; set; }
	
		public GroceryItem() { }
	
		public GroceryItem(string name, decimal price)
		{
			this.Name = name;
			this.Price = price;
		}
	
		public abstract decimal FindCost()
	}
	
	public class PurchasedItem : GroceryItem
	{
		public int Quantity { get; set; }
		public double Weight { get; internal set; }
	
		public override decimal FindCost()
		{
			decimal cost = Quantity * Price * 1.1m; //1.1m is GST
			return cost;
		}
	}
	
	public class FreshItem : GroceryItem
	{
		public double Weight { get; set; } //kg
	
		public override decimal FindCost()
		{
			Console.WriteLine("FreshItem FindCost()");
			decimal cost = (decimal)Weight * Price;
			return cost;
		}
	}
