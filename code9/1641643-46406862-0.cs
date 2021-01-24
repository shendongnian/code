	using System.Linq;
	class Program
	{
		static void Main (string[] args)
		{
			var s = "1204852384 / 1245983245";
			var p = s.Split(" ".ToCharArray())
			.Select(num => { if (long.TryParse(num, out var number)) return (long?)number; return null; })
			.Where( num => num.HasValue)
			.Select(num => num.Value)
			.ToList();
			long first = long.MinValue;
			long last = long.MinValue;
			if (p.Count >= 2)
			    last = p.Last ();
			if (p.Count > 0)
			    first = p.First ();
			Console.WriteLine (first);
			Console.WriteLine (last);
			Console.ReadLine ();
		}
	}
