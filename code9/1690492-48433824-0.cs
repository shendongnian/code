	public static class ExtensionMethods
	{
		static public IEnumerable<T> Minus<T>(this IEnumerable<T> input, IEnumerable<T> removal)
		{
			var result = input.ToList();
			foreach (var r in removal)
			{
				if (result.Contains(r)) result.Remove(r);
			}
			return result;
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var L1 = new List<int>{1,1,2};
			var L2 = new List<int>{1};
			var L3 = L1.Minus(L2);
			
			
			foreach (var l in L3)
			{
				Console.WriteLine(l);
			}
		}
	}
