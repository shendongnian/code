    public class Program
	{
		public static void Main()
		{
			List<Car> cars = new List<Car> { new Car(), new Car() };
	
			var b = cars[0];
	
			var a = new { Brand = "Something", Price = 123M};  //Notice this is an anonymous type. You can use any object, as long as the properties match.
	
			a.CopyTo(cars[0]);
			
			Console.WriteLine("Brand: {0}", cars[0].Brand);
			Console.WriteLine("Price: {0}", cars[0].Price);
		}
	}
