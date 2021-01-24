	using System;
	using System.Collections.Generic;
	using System.Linq;
	public static class Extensions
	{
		// Extension method: filters elements by type
		public static List<T> GetTypes<T>(this List<T> elements, Type type)
					=> elements.Where(x => x.GetType() == type).ToList();
	}
	
	public class Program
	{
		// demonstrates how it is working
		public static void Main()
		{
			var elements = new List<object> {
				(int)3, (string)"Hello", (int)5, (string)"World"
			};
			var filteredList = elements.GetTypes(typeof(System.String));
			foreach (var x in filteredList) Console.WriteLine($"{x}");
		}
	}
						
