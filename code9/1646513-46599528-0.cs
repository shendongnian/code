	using System;
	using System.Linq;
	using Bogus;
	public class Program
	{
		public static void Main()
		{
			var productsFactory = new Faker<Product>()
				.StrictMode(true)
				.RuleFor(p => p.TransactionDate, f => f.Date.Between(DateTime.UtcNow.AddDays(-100), DateTime.UtcNow))
				.RuleFor(p => p.Category, f => f.Commerce.ProductAdjective())
				.RuleFor(p => p.Price, f => f.Random.Decimal(10, 100))
				.RuleFor(p => p.PaymentType, f => f.PickRandomWithout(PaymentType.Unknown))
				.RuleFor(p => p.Name, f => f.Commerce.ProductName())
				.RuleFor(p => p.City, f => f.Address.City())
				.RuleFor(p => p.State, f => f.Address.State())
				.RuleFor(p => p.Country, f => f.Address.Country());
			var products = productsFactory.Generate(50);
			var userSearch = products.Skip(3).First().Name.Substring(2, 3);
			var productSearch = products.Where(product => product.Name.IndexOf(userSearch, StringComparison.CurrentCultureIgnoreCase) >= 0);
			foreach (var result in productSearch)
			{
				Console.WriteLine(String.Format("{0:G} {1} {2:N2}", result.TransactionDate, result.Name, result.Price));
			}
			Console.ReadKey();
		}
	}
	public class Product
	{
		public DateTime TransactionDate { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
		public PaymentType PaymentType { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}
	public enum PaymentType
	{
		Unknown,
		Mastercard,
		Visa,
		Amex,
	}
