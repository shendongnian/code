	using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			Dictionary<string, string[]> cars = new Dictionary <string,string[]>() {
					{"importcar",    new string[] {"audi", "bmw", "mercedes"}},
					{"domesticcar",  new string[] {"chevy", "mustang"}},
					{"truck", new string[]{"ford", "gmc", "chevy", "toyota"}}
				};
			var query = cars.Where(x => x.Value.Contains("CHEVY", StringComparer.InvariantCultureIgnoreCase)).ToArray();
			for (int i = 0; i < query.Length; i++)
			{
				cars.Remove(query[i].Key);	
			}
			Console.WriteLine(cars.Count);
		}
	}
