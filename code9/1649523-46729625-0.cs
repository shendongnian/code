	using System;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var x = "#K06[1234567-0257;S2W546#20-H2]"; 
		
			var y = x.Split('-')[1].Replace(";", "").Replace("#", "");
			Console.WriteLine(y == "0257S2W54620");
			Console.WriteLine(y);
		}
	}
