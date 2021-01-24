	public static void Main() {
		int n = 5;
		Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
		for (int i = 0 ; i != 100000 ; i++) {
			object a = n;
		}
		Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
	}
