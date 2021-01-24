	public double NestedParamArrayLoop(Func<int[], double> delegatedFunction, List<LoopController> loopControllers)
	{
		return
			loopControllers
				.Select(lc => delegatedFunction(lc.ToArray()))
				.Sum();
	}
