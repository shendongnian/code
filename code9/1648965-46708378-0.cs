    using System;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var x = "12,13,14";
			var k = "12";
		
            // if you dont want int just remove `.Select(int.Parse)`
            var results = x.Split(',').Select(int.Parse)
				.Intersect(k.Split(',').Select(int.Parse))
            
			foreach(var item in results)
			{
				Console.WriteLine(item);
			}
		}
	}
