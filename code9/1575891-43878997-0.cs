    using System;
	using System.Text.RegularExpressions;
						
	public class Program
	{
		public static void Main()
		{
			string data = "-33,167.74   NHP       1,503         05/09/2017";
			
			string regex = @"((-|)\b\d[\d,.\/]*\b)";
			var matches = Regex.Matches(data, regex, RegexOptions.Multiline);
			
			int Id = Convert.ToInt16(matches[1].Groups[0].ToString().Replace(",", ""));
			decimal Amount = Convert.ToDecimal(matches[0].Groups[0].ToString());
			DateTime date = Convert.ToDateTime(matches[2].Groups[0].ToString());
			string name = Regex.Replace(data, regex, "").ToString().Trim();
			
			Console.WriteLine("Id: " + Id);
			Console.WriteLine("Amount: " + Amount);
			Console.WriteLine("date: " + date);
			Console.WriteLine("name: " + name);
		}
	}
