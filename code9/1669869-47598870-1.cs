	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Globalization;
						
	public class Program
	{
		public static void Main()
		{
			Dictionary<string, string[]> cars = new Dictionary <string,string[]>() {
					{"importcar",    new string[] {"audi", "bmw", "mercedes"}},
					{"domesticcar",  new string[] {"chevy", "mustang"}},
					{"truck", new string[]{"ford", "gmc", "chevy", "toyota"}}
				};
			var query = cars.Where(x => x.Value.Contains(" CHEVY", new TrimStringComparer())).ToArray();
			for (int i = 0; i < query.Length; i++)
			{
				cars.Remove(query[i].Key);	
			}
			Console.WriteLine(cars.Count);
		}
	
	}
	class TrimStringComparer : IEqualityComparer<String>
	{
		public bool Equals(string x, string y)
		{
			return x.Trim().ToString(CultureInfo.InvariantCulture).ToLower().Equals(y.Trim().ToString(CultureInfo.InvariantCulture).ToLower());
		}
	
		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
