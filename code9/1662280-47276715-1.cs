    using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Program
	{
		static public List<string> Normalize(string input, List<string> dictionary)
		{
			return dictionary.Where(a => input.Contains(a)).ToList();		
		}
	
		public static void Main()
		{
			List<string> dictionary = new List<string>
			{
				"COMPUTER","FIVE","CODE","COLOR","FOO"
			};
			string input = "COMPUTERFIVECODECOLORBAR";
			var normalized = Normalize(input, dictionary);
			foreach (var s in normalized)
			{
				Console.WriteLine(s);
			}
		}
	}
