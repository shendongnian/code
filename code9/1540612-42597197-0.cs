	using System;
	using System.Linq;
					
	public class Program
	{
		public static void Main()
		{	
			Console.WriteLine(ParseNumeric("۱۱۷"));
    	}
	
		public static int ParseNumeric(string input)
		{
			return int.Parse(string.Concat(input.Select(c =>
				"+-".Contains(c)
            		? c.ToString()
					: char.GetNumericValue(c).ToString())));
		}
	}
