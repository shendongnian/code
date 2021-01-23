	using System;
	using System.Linq;
					
	public class Program
	{
		public static void Main()
		{
			var strValue = "a/ new string, with some@ values&";
		
			Console.WriteLine(strValue.Replace("/@&", '_'));
		}
	}
	public static class Extensions {
		public static string Replace(this string source, string blacklist, char letter) => 
			new string(source.Select(c => blacklist.Contains(c) ? letter : c).ToArray());
	}
