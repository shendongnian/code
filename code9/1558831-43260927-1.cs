	using System;
	using System.Linq;
					
	public class Program
	{
		public static void Main()
		{
			string extractTitle(string x) => x.Substring(x.IndexOf(". ") + 2);
			string extractNumber(string x) => x.Remove(x.IndexOf(". ")).Substring(1);
			string build(string n, string t) => $"<h{n}>{t}</h{n}>";
		
			var inputs = new [] {
				"h1. this is the Header",
				"h3. this one the header too",
				"h111. and this" };
		
			foreach (var line in inputs.Select(x => build(extractNumber(x), extractTitle(x))))
			{
				Console.WriteLine(line);
			}
		}
	}
