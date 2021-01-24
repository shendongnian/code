	using System;
	using System.Linq;
					
	public class Program
	{
		static string extractTitle(string x)
		{
			return x.Substring(x.IndexOf(". ") + 2);
		}
		static string extractNumber(string x)
		{
			return x.Remove(x.IndexOf(". ")).Substring(1);
		}
		static string build(string n, string t)
		{
			return string.Format("<h{0}>{1}</h{0}>", n, t);
		}
	
		public static void Main()
		{
			var inputs = new []{
				"h1. this is the Header",
				"h3. this one the header too",
				"h111. and this"
			};
		
			foreach (var line in inputs.Select(x => build(extractNumber(x), extractTitle(x))))
			{
				Console.WriteLine(line);
			}
		}
	}
