	public enum ProductCategory
	{
		Electric,
		Household,
		Garden,
		Miscellaneous
	}
	public class Product
	{
		public ProductCategory Category { get; }
		public Product(ProductCategory category)
		{
			this.Category = category;
		}
		public Product() : this(ProductCategory.Miscellaneous)
		{
		}
	}
	static void Main()
	{
 		Product p1 = new Product();
		Console.WriteLine(p1.Category); // output: Miscellaneous
		Console.ReadKey();
	}
