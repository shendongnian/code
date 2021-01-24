	public string Evaluate()
	{
		foreach (var customAction in EnumerateActions())
		{
			if (!customAction.Execute())
				return customAction.Error;
		}
		return "Success...";
	}
	
	public IEnumerable<CustomAction> EnumerateActions()
	{
		yield return new CustomAction(a1, "Error for A1");
		yield return new CustomAction(a2, "Error for A2");
		...
	}
	
	public class CustomAction
	{
		public Func<bool> Execute { get; }
		public string Error { get; }
		public CustomAction(Func<bool> action, string error)
		{
			Execute = action;
			Error = error;
		}
	}
