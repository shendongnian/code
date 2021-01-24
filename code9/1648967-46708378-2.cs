    using System;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var ReturnStr = "12,13";
			var ReturnBOM = "14,15,13";
			
			// Convert string to array with Split(',')
			// if you dont want int just remove `.Select(int.Parse)`
			var ReturnStrElements = ReturnStr.Split(',').Select(int.Parse);
			var ReturnBOMElements = ReturnBOM.Split(',').Select(int.Parse);
		
            // Keep only common elements
            var results = ReturnStrElements.Intersect(ReturnBOMElements);
			
			foreach(var item in results)
			{
				Console.WriteLine(item);
			}
		}
	}
