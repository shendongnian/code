	public static void Main()
	{
		IList<B> b = new List<B>(){ new B() };
		IList<A> a = new List<A>(b);
		if(a.All(x=>x is B))
			Console.WriteLine("B");
		else if(a.All(x=>x is C))
			Console.WriteLine("C");
		else
			Console.WriteLine("A");
	}
	
