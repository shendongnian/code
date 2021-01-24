	void Main()
	{
		var grettings = new List<string>()
				{
					"Hey",
					"Hi",
					"How"
				};
	
		var currentGreeting = "Hey are you ok ?";
	
		var b = grettings.Any(BundleLambda(currentGreeting) );
		b.Dump();
	}
	
	public static Func<string, bool> BundleLambda(string target)
	{
		return a=> target.Contains(a);
	}
