	using System;
	using System.Linq;
	
	public class Program
	{
		const char space = ' ';
		
		public static string DoHomework(string input)
		{
			return new string
			(
				input.Select( (c,i) => 
				{
					if (i == 0 || i == input.Length-1) return c;
					if (c == space) return input[i-1];
					if (input[i+1] == space) return space;
					return c;
				}).ToArray()	
			);
		}
		
		public static void Main()
		{
			var input = "Hey hello world";
			var output = DoHomework(input);
		
			Console.WriteLine(output);
		}
	}
