	public class Clerk
	{
		public double Number {get;set;}
		public string Name {get;set;}
		//I've used a dictionary type below; the first int for the month number, the second for the clerk's monthly sales
		public IDictionary<int, int> SalesFigures {get;set;} 
		public Clerk (double number, string name) 
		{
			this.Number = number;
			this.Name = name;
			this.SalesFigures = new Dictionary<int, int>();
		}
	}
