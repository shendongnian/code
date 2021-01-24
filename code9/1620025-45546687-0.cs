	using System;
	using System.Linq;
	using System.Collections.Generic;
	public class Program
	{
		public static void Main()
		{
			var items = Enumerable.Range(1, 100)
								  .Select(value => value % 10)
								  .Select(value => new mappingData{ a = "a" + value, b = "b" + value, c = value });
			var hashSet = new HashSet<mappingData>(items);
			
            // Outputs only first ten elements
			foreach(var item in hashSet)
			{
				Console.WriteLine(item);
			}
			
		}
		
		public struct mappingData
		{
			public string a;
			public string b;
			public int c;
			
			public override string ToString()
			{
				return $"{a} {b} {c}";
			}
		}
	}
