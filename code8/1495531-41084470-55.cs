	[return: TupleElementNames(new string[] {
		"sum",
		"count"
	})]
	public ValueTuple<int, int> DoStuff(IEnumerable<int> values)
	{
		ValueTuple<int, int> result;
		result..ctor(0, 0);
		foreach (int current in values)
		{
			result.Item1 += current;
			result.Item2++;
		}
		return result;
	}
	
	public void Foo()
	{
		ValueTuple<int, int> expr_0E = this.DoStuff(Enumerable.Range(0, 10));
		int item = expr_0E.Item1;
		int arg_1A_0 = expr_0E.Item2;
	}
