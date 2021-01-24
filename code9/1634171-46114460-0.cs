    class ImplementsChildInterface : IChildInterface
	{
		public void Use(IChildInterface other)
		{ // idea: if other is IChildInterface, use this method
			Debug.WriteLine("ImplementsChildInterface.Use(IChildInterface)");
		}
		public void Use<T>(T other) where T : IInterface
		{ // idea: if above method is not applicable, use this method
			Debug.WriteLine("ImplementsChildInterface.Use(IInterface)");
		}
	}
