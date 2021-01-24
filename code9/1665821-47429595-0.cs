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
	
	public double NestedParamArrayLoop(Func<int[], double> delegatedFunction, List<LoopController> loopControllers)
	{
		double total = 0;
	
		foreach (LoopController loopController in loopControllers)
		{
			total += delegatedFunction(loopController.Enumerate().ToArray());
		}
	
		return total;
	}
	
	public class LoopController
	{
		public int Start;
		public int End;
		public int Increment;
	
		public IEnumerable<int> Enumerate()
		{
			var i = this.Start;
			while (i <= this.End)
			{
				yield return i;
				i += this.Increment;
			}
		}
	}
