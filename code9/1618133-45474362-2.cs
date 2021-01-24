	internal class ExecutionParametersJson
	{
		[JsonProperty("Factor")]
		public string Factor { get; set; }
		public string SomeProperty { get; set; }
		[JsonProperty("Penalty")]
		public string Penalty { get; set; }
		[JsonProperty("Origin")]
		public string Origin { get; set; }
		public int SomeOtherProperty { get; set; }
		[JsonProperty("InterFactor")]
		public string InterFactor { get; set; }
	}
