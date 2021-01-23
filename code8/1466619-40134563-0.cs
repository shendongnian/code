	public class Result
	{
		private const string defaultMsg = "xxx";
		private const bool defaultIsPositive = false;
		
		public string Msg { get; set; } = defaultMsg;
		public bool IsPositive { get; set; } = defaultIsPositive;
		
		public void Reset()
		{
			Msg = defaultMsg;
			IsPositive = defaultIsPositive;
		}
	}
	
