	using System;
	using System.Linq;
	using System.Collections.Generic;
					
	public class Program
	{
		public static void Main()
		{
			string extractTitle(string x) => x.Substring(x.IndexOf(". ") + 2);
			string extractNumber(string x) => x.Remove(x.IndexOf(". ")).Substring(1);
			string print(string n, string t) => $"<h{n}>{t}</h{n}>";
		
			var inputs = new []{"h1. this is the Header", "h3. this one the header too", "h111. and this"};
		
			foreach (var input in inputs.Select(x =>
                new { Title = extractTitle(x), Number = extractNumber(x)}))
			{
				Console.WriteLine(print(input.Number, input.Title));
			}
		}
	}
