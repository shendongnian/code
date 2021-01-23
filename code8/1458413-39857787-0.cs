	public static void Main()
	{
		var result1 = GetSecondSmallest(new List<int>
		{
		4, 2, 3, 1, 6, 8
		}); // Should return 2
		var result2 = GetSecondSmallest(new List<MyComparable>
		{
		new MyComparable('x')
        }); // Should return null
		Console.WriteLine("result1=" + result1.Item1);
		Console.WriteLine("result2 == null: " + (result2 == null));
	}
	public static Tuple<T> GetSecondSmallest<T>(List<T> items)where T : IComparable
	{
		return items.Skip(1).Select(v => Tuple.Create(v)).FirstOrDefault();
	}
