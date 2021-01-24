	public class InputModel
	{
		public string legacy { get; set; }
		public string subid { get; set; }
		public string converted { get; set; }
		public string licPart { get; set; }
		public string count { get; set; }
	}
	
	public class OutputModel
	{
		public string legacy { get; set; }
		public string subid { get; set; }
		public IList<string> list { get; set; }
		public string licPart { get; set; }
	}
