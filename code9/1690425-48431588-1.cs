	static int add(string a, string b)
	{
		var c = a.ToCharArray().Union(b.ToCharArray()).Select(f=>(int)f).Sum();
		return c;
	}
