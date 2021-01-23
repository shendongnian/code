	public class LibrarySettings
	{
		public LibrarySettings(bool isOperationOneEnabled, double operationOneRate,
			bool isOperationTwoEnabled, double operationTwoRate)
		{
			IsOperationOneEnabled = isOperationOneEnabled;
			OperationOneRate = operationOneRate;
			IsOperationTwoEnabled = isOperationTwoEnabled;
			OperationTwoRate = operationTwoRate;
		}
		public bool IsOperationOneEnabled { get; }
		public double OperationOneRate { get; }
		public bool IsOperationTwoEnabled { get; }
		public double OperationTwoRate { get;}
	}
