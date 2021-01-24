	using System;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var k = @"System
	System.Collection.Generic
	System.Generic
	System.Linq
	System.Linq.Collection.Generic";
				
            // We split by new line, then order them by occurrence count of '.'
			var ordered = k.Split('\n').OrderBy(x => x.Count(l => l == '.'))
			foreach (var item in ordered)
				Console.WriteLine(item);
		}
	}
