	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Globalization;
						
	public class Program
	{
		public static void Main()
		{
			Dictionary<string, List<string>> cars = new Dictionary <string, List<string>>() {
					{"importcar",    new List<string>() {"audi", "bmw", "mercedes"}},
					{"domesticcar",  new List<string>() {"chevy", "mustang"}},
					{"truck", new List<string>(){"ford", "gmc", "chevy", "toyota"}}
				};
			var query = cars.Where(x => x.Value.Contains(" CHEVY", new TrimStringComparer())).ToArray();
			for (int i = 0; i < query.Length; i++)
			{
				cars.Remove(query[i].Key);	
			}
			Console.WriteLine(cars.Count); //Or any other logic you need...
		}
	
	}
	class TrimStringComparer : IEqualityComparer<String> //Use this instead of StringComparer.InvariantCultureIgnoreCase if you need to Trim() both values in the comparison
	{
		public bool Equals(string x, string y)
		{
			return x.Trim().ToLowerInvariant().Equals(y.Trim().ToLowerInvariant());
		}
	
		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
