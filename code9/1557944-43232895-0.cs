    using System;
	using System.Text.RegularExpressions;
						
	public class Program
	{
		public static void Main()
		{
			string data = " 1 -1 -1;-2 1;2 1;2-4 -1;3-5 1-5;-1 1-5;1 $pages$;5";
			string regex = @"\d|\-\d|\$|\w|\s+";
			var delimiters = Regex.Replace(data, regex, string.Empty);
			Console.WriteLine(delimiters);
		}
	}
