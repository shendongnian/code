	public double NestedParamArrayLoop(Func<int[], double> delegatedFunction, List<LoopController> loopControllers)
	{
		double total = 0;
	
		foreach (LoopController loopController in loopControllers)
		{
			total += delegatedFunction(loopController.ToArray());
		}
	
		return total;
	}
