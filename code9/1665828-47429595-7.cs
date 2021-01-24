	void Main()
	{
		var loopControllers = new List<LoopController>()
		{
			new LoopController() { Start = 4, End = 10, Increment = 2 },
			new LoopController() { Start = 17, End = 19, Increment = 1 },
		};
		Console.WriteLine(NestedParamArrayLoop(DelegatedFunction, loopControllers));
	}
	
	public double DelegatedFunction(params int[] arguments)
	{
		long product = 1;
		for (int i = 0; i < arguments.Count(); i++)
			product *= arguments[i];
		return product;
	}
