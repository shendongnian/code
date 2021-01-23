	using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			string str = "how to replace different words from list found in string with specific word"; 
			var valueList = new List<string> { "replace", "string", "specific", "found", "how", "word"};  
			
			var result = valueList.Aggregate(str, (current, c) => current.Replace(c, "x"));
			Console.WriteLine(result);
		}
	}
