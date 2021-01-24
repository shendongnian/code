    using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.Reflection;
						
	public static class ExtensionMethods
	{
		public static Dictionary<string, object> Extract<T>(this T input) where T : class
		{
			return input
				.GetType()
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.ToDictionary( p => p.Name, p => p.GetValue(input));
		}
	
	}
	
	public class Program
	{
		public static void someFunction(object input)
		{
			var parameters = input.Extract();  //Magic
			
			Console.WriteLine("There were {0} parameters, as follows:", parameters.Count);
			foreach (var p in parameters)
			{
				Console.WriteLine("{0}={1}", p.Key, p.Value);
			}
		}
		
		public static void Main()
		{
			someFunction(new { number = 3, text = "SomeText" } );
			someFunction(new { another = 3.14F, example = new DateTime(2017, 12, 15) } );
		}
	}
